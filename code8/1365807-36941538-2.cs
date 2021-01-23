        static void ConversionTest( string _outfilename, string _infilename )
        {
            try
            {
                using( var reader = new MediaFoundationReader(_infilename) )
                {
                    // Create a wave format for 16-bit pcm at 8000 samples per second.
                    int channels = reader.WaveFormat.Channels;
                    int rate = 8000;
                    int rawsize = 2;
                    int blockalign = rawsize * channels; // this is the size of one sample.
                    int bytespersecond = rate * blockalign;
                    var midformat =
                        WaveFormat.CreateCustomFormat( WaveFormatEncoding.Pcm,
                                                       rate,
                                                       channels,
                                                       bytespersecond,
                                                       blockalign,
                                                       rawsize * 8 );
                    // And a conversion stream to turn input into 16-bit PCM.
                    var midstream = new MediaFoundationResampler(reader, midformat);
                    //var midstream = new WaveFormatConversionStream(midformat, reader);
                    // The output stream is our custom stream.
                    var outstream = new PcmToALawConversionStream(midstream);
                    WaveFileWriter.CreateWaveFile(_outfilename, outstream);
                }
            }
            catch( Exception _ex )
            {
            }
        }
