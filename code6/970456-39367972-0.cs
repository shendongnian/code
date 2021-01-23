    using System;
    using System.Media;
    using NAudio;
    using NAudio.Wave;
    class sound
        {
            static WaveFileWriter waveFile;
            public static void Main()
            {
                //WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(0);
                Console.WriteLine("Now recording...");
                WaveInEvent waveSource = new WaveInEvent();
                //waveSource.DeviceNumber = 0;
                waveSource.WaveFormat = new WaveFormat(44100, 1);
                waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
                string tempFile = (@"C:\Users\user\Desktop\test1.wav");
                waveFile = new WaveFileWriter(tempFile, waveSource.WaveFormat);
                waveSource.StartRecording();
                Console.WriteLine("Press enter to stop");
                Console.ReadLine();
                waveSource.StopRecording();
                waveFile.Dispose();
            }
            static void waveSource_DataAvailable(object sender, WaveInEventArgs e)
            {
                waveFile.WriteData(e.Buffer, 0, e.BytesRecorded);
            }
        }
