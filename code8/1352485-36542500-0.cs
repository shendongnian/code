    for (int n = 0; n < WaveIn.DeviceCount; n++)
         {
               this.recordingDevices.Add(WaveIn.GetCapabilities(n).ProductName);
               comboBoxAudio.Items.Add(WaveIn.GetCapabilities(n).ProductName);
         }
