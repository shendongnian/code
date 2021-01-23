	private async Task ToggleRecordStop()
	{
		if (recordStopButton.Content.Equals("Record"))
		{
			graph.Start();
			recordStopButton.Content = "Stop";
		}
		else if (recordStopButton.Content.Equals("Stop"))
		{
			// Good idea to stop the graph to avoid data loss
			graph.Stop();
			TranscodeFailureReason finalizeResult = await fileOutputNode.FinalizeAsync();
			if (finalizeResult != TranscodeFailureReason.None)
			{
				// TODO: Finalization of file failed. Check result code to see why, propagate error message
				return;
			}
			recordStopButton.Content = "Record";
		}
	}
