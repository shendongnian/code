	AudioGraphSettings settings = new AudioGraphSettings(AudioRenderCategory.Media);
	settings.QuantumSizeSelectionMode = QuantumSizeSelectionMode.LowestLatency;
    // Use the selected device from the outputDevicesListBox to preview the recording
	settings.PrimaryRenderDevice = outputDevices[outputDevicesListBox.SelectedIndex - 1];
	CreateAudioGraphResult result = await AudioGraph.CreateAsync(settings);
	if (result.Status != AudioGraphCreationStatus.Success)
	{
		// TODO: Cannot create graph, propagate error message
		return;
	}
	AudioGraph graph = result.Graph;
	// Create a device output node
	CreateAudioDeviceOutputNodeResult deviceOutputNodeResult = await graph.CreateDeviceOutputNodeAsync();
	if (deviceOutputNodeResult.Status != AudioDeviceNodeCreationStatus.Success)
	{
		// TODO: Cannot create device output node, propagate error message
		return;
	}
	deviceOutputNode = deviceOutputNodeResult.DeviceOutputNode;
	// Create a device input node using the default audio input device
	CreateAudioDeviceInputNodeResult deviceInputNodeResult = await graph.CreateDeviceInputNodeAsync(MediaCategory.Other);
	if (deviceInputNodeResult.Status != AudioDeviceNodeCreationStatus.Success)
	{
		// TODO: Cannot create device input node, propagate error message
		return;
	}
	deviceInputNode = deviceInputNodeResult.DeviceInputNode;
	// Because we are using lowest latency setting, we need to handle device disconnection errors
	graph.UnrecoverableErrorOccurred += Graph_UnrecoverableErrorOccurred;
    // Start setting up the output file
    FileSavePicker saveFilePicker = new FileSavePicker();
	saveFilePicker.FileTypeChoices.Add("Pulse Code Modulation", new List<string>() { ".wav" });
	saveFilePicker.FileTypeChoices.Add("Windows Media Audio", new List<string>() { ".wma" });
	saveFilePicker.FileTypeChoices.Add("MPEG Audio Layer-3", new List<string>() { ".mp3" });
	saveFilePicker.SuggestedFileName = "New Audio Track";
	StorageFile file = await saveFilePicker.PickSaveFileAsync();
	// File can be null if cancel is hit in the file picker
	if (file == null)
	{
		return;
	}
	MediaEncodingProfile fileProfile = CreateMediaEncodingProfile(file);
	// Operate node at the graph format, but save file at the specified format
	CreateAudioFileOutputNodeResult fileOutputNodeResult = await graph.CreateFileOutputNodeAsync(file, fileProfile);
	if (fileOutputNodeResult.Status != AudioFileNodeCreationStatus.Success)
	{
		// TODO: FileOutputNode creation failed, propagate error message
		return;
	}
	fileOutputNode = fileOutputNodeResult.FileOutputNode;
	// Connect the input node to both output nodes
	deviceInputNode.AddOutgoingConnection(fileOutputNode);
	deviceInputNode.AddOutgoingConnection(deviceOutputNode);
