     WasapiCapture capture;
     private void buttonStart_Click(object sender, EventArgs f)
        {
           if(capture == null)
                    capture = new new CSCore.SoundIn.WasapiLoopbackCapture();
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
                }
            else {   
                    //stop recording
                    capture.Stop();
                    capture = null;
                }
            }
        }
