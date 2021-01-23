    //Creating PCM Encoding properties
    var pcmEncoding = AudioEncodingProperties.CreatePcm(16000, 1, 16);
    var result = await AudioGraph.CreateAsync(
        new AudioGraphSettings(AudioRenderCategory.Speech)
        {
            DesiredRenderDeviceAudioProcessing = AudioProcessing.Raw,
            AudioRenderCategory = AudioRenderCategory.Speech,
            EncodingProperties = pcmEncoding
        }
    );
    graph = result.Graph;
