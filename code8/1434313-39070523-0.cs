	private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
	{
		var backgroundWorker = sender as BackgroundWorker;
		foreach (mp3file file in fileList)
		{
			string outputfilename = fbd.SelectedPath + "\\" + file.name + ".wav";
			using (Mp3FileReader reader = new Mp3FileReader(file.path))
			{
				using (WaveStream convertedStream = WaveFormatConversionStream.CreatePcmStream(reader)){
				WaveFileWriter.CreateWaveFile(outputfilename, convertedStream);
			}
			backgroundWorker.ReportProgress();
		}
	}
	private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBar1.Value = e.ProgressPercentage;
	}
	private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		// Do something When the loop or operation is completed.
	}
