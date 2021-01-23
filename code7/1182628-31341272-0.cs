      private void buttonStart_Click(object sender, EventArgs e)
    {
        buttonStart.Enabled = false;
        buttonStop.Enabled = true;
        waveSource = new WaveIn();
        waveSource.WaveFormat = new WaveFormat(44100, 2);
        waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
        waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);
        waveFile = new WaveFileWriter(@"C:\one\Test0010.wav", waveSource.WaveFormat);
        waveSource.StartRecording();
        timerSoundRecord.Start();
      } 
    int length = 0;
    void waveSource_DataAvailable(object sender, WaveInEventArgs e)
    {
        if (waveFile != null)
        {           
            waveFile.Write(e.Buffer, 0, e.BytesRecorded);
            waveFile.Flush();
            var lenght = (int)(waveFile.Length / waveFile.WaveFormat.AverageBytesPerSecond);
            if (lenght == 6)
            {
                timerSoundRecord.Stop();
                waveSource.StopRecording();
                labelTime.Text = @"00:0" + length;
                progressBarRecordSound.Value++;
                buttonStop.Enabled = false;
                buttonStart.Enabled = true;
            }
        }
    }
    private void timerSoundRecord_Tick(object sender, EventArgs e)
    {
            labelTime.Text = @"00:0" + length;
            progressBarRecordSound.Value++;
    }
