      public class AsioWavProvidor :IWaveProvider
            {
                private bool EndSignaled = false;
                public Action EndofAudioData;
                public Mp3FileReader Mp3Reader;
                public AsioWavProvidor(string mp3File)
                {
                    Mp3Reader = new Mp3FileReader(mp3File);
                }
                public TimeSpan CurrentTime { get { return Mp3Reader.CurrentTime; } }
                
               
     public int Read(byte[] buffer, int offset, int count)
                {
                    var retCount = Mp3Reader.Read(buffer, offset, count);
                    if (retCount == 0)
                    {
                       if (EndofAudioData != null && !EndSignaled)
                        {
                           
                            EndSignaled = true;
                            System.Threading.Tasks.Task.Run(() =>
                            {
                                try
                                {
                                    EndofAudioData();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                }
                            });
                            
                        }
                        return count;
                    }
                    return retCount;
                }
