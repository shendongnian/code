    bool isRunning = false;
    WasapiCapture capture;
     private void buttonStart_Click(object sender, EventArgs f)
        {
    
                 if(!isRunning) {
                    capture.Initialize();
                    capture.DataAvailable += (s, e) =>
                    {
                        //save the recorded audio
                        using (WaveWriter w = new WaveWriter(@directory, capture.WaveFormat))
                        {
                            w.Write(e.Data, e.Offset, e.ByteCount);
                        }
                    };
    
                    //start recording
                    capture.Start();
                    isRunning = true;
                }
                else {   
                    //stop recording
                    capture.Stop();
                    isRunning = false;
                }
            }
        }
