                using (WasapiCapture capture = new WasapiLoopbackCapture()) {                    
                    capture.Initialize();                    
                    using(MemoryStream mstr = new MemoryStream())
                    using (WaveWriter wvWriter = new WaveWriter(mstr, capture.WaveFormat)) { 
                         capture.DataAvailable += 
                               (object sender, DataAvailableEventArgs e) => {                                    
                                    wvWriter.Write(e.Data, e.Offset, e.ByteCount);
                                    // Do some stuff with that Data!
                               }
                    }
                }
