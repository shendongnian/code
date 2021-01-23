        public static byte[] ConvertWavTo8000Hz16BitMonoWav(byte[] inArray)
        {
            using (var mem = new MemoryStream(inArray))
            {
                using (var reader = new WaveFileReader(mem))
                {
                    using (var converter = WaveFormatConversionStream.CreatePcmStream(reader))
                    {
                        using (var upsampler = new WaveFormatConversionStream(new WaveFormat(8000, 16, 1), converter))
                        {
                            byte[] data;
                            using (var m = new MemoryStream())
                            {
                                upsampler.CopyTo(m);
                                data = m.ToArray();
                            }
                            using (var m = new MemoryStream())
                            {
                                // to create a propper WAV header (44 bytes), which begins with RIFF 
                                var w = new WaveFileWriter(m, upsampler.WaveFormat);
                                // append WAV data body
                                w.Write(data,0,data.Length);
                                return m.ToArray();
                            }   
                        }
                    }
                }
            }
        }
