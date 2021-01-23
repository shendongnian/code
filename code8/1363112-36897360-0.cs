    public class FadeWeaver
    {
        static
        public
        void
        FadeWeave( string _outfilename,
                   params string [] _inpatterns )
        {
            WaveFileWriter output = null;
            WaveFormat waveformat = null;
            float [] sample = null;
            float volume = 1.0f;
            float volumemod = 0.0f;
            // Add .wav extension to the output if not specified.
            string extension = Path.GetExtension(_outfilename);
            if( string.Compare(extension, ".wav", true) != 0 ) _outfilename += ".wav";
            // Assume we're using the current directory.  Let's get the
            // list of filenames.
            List<string> filenames = new List<string>();
            foreach( string pattern in _inpatterns )
            {
                filenames.AddRange(Directory.GetFiles(Directory.GetCurrentDirectory(), pattern));
            }
            try
            {
                // Alrighty.  Let's march over them.  We'll index them (rather than
                // foreach'ing) so that we can monitor first/last file.
                for( int index = 0; index < filenames.Count; ++index )
                {
                    // Grab the file and use an 'audiofilereader' to load it.
                    string filename = filenames[index];
                    using( WaveFileReader reader = new WaveFileReader(filename) )
                    {
                        // Get our first/last flags.
                        bool firstfile = (index == 0 );
                        bool lastfile = (index == filenames.Count - 1);
                        // If it's the first...
                        if( firstfile )
                        {
                            // Initialize the writer.
                            waveformat = reader.WaveFormat;
                            output = new WaveFileWriter(_outfilename, waveformat);
                        }
                        else
                        {
                            // All files must have a matching format.
                            if( !reader.WaveFormat.Equals(waveformat) )
                            {
                                throw new InvalidOperationException("Different formats");
                            }
                        }
                        long fadeinsamples = 0;
                        if( !firstfile )
                        {
                            // Assume 1 second of fade in, but set it to total size
                            // if the file is less than one second.
                            fadeinsamples = waveformat.SampleRate;
                            if( fadeinsamples > reader.SampleCount ) fadeinsamples = reader.SampleCount;
                        }
                        // Initialize volume and read from the start of the file to
                        // the 'fadeinsamples' count (which may be 0, if it's the first
                        // file).
                        volume = 0.0f;
                        volumemod = 1.0f / (float)fadeinsamples;
                        int sampleix = 0;
                        while( sampleix < (long)fadeinsamples )
                        {
                            sample = reader.ReadNextSampleFrame();
                            for( int floatix = 0; floatix < waveformat.Channels; ++floatix )
                            {
                                sample[floatix] = sample[floatix] * volume;
                            }
                            // Add modifier to volume.  We'll make sure it isn't over
                            // 1.0!
                            if( (volume = (volume + volumemod)) > 1.0f ) volume = 1.0f;
                            // Write them to the output and bump the index.
                            output.WriteSamples(sample, 0, sample.Length);
                            ++sampleix;
                        }
                        // Now for the time between fade-in and fade-out.
                        // Determine when to start.
                        long fadeoutstartsample = reader.SampleCount;
                        //if( !lastfile )
                        {
                            // We fade out every file except the last.  Move the
                            // sample counter back by one second.
                            fadeoutstartsample -= waveformat.SampleRate;
                            if( fadeoutstartsample < sampleix ) 
                            {
                                // We've actually crossed over into our fade-in
                                // timeframe.  We'll have to adjust the actual
                                // fade-out time accordingly.
                                fadeoutstartsample = reader.SampleCount - sampleix;
                            }
                        }
                        // Ok, now copy everything between fade-in and fade-out.
                        // We don't mess with the volume here.
                        while( sampleix < (int)fadeoutstartsample )
                        {
                            sample = reader.ReadNextSampleFrame();
                            output.WriteSamples(sample, 0, sample.Length);
                            ++sampleix;
                        }
                        // Fade out is next.  Initialize the volume.  Note that
                        // we use a bit-shorter of a time frame just to make sure
                        // we hit 0.0f as our ending volume.
                        long samplesleft = reader.SampleCount - fadeoutstartsample;
                        volume = 1.0f;
                        volumemod = 1.0f / ((float)samplesleft * 0.95f);
                        // And loop over the reamaining samples
                        while( sampleix < (int)reader.SampleCount )
                        {
                            // Grab a sample (one float per channel) and adjust by
                            // volume.
                            sample = reader.ReadNextSampleFrame();
                            for( int floatix = 0; floatix < waveformat.Channels; ++floatix )
                            {
                                sample[floatix] = sample[floatix] * volume;
                            }
                            // Subtract modifier from volume.  We'll make sure it doesn't
                            // accidentally go below 0.
                            if( (volume = (volume - volumemod)) < 0.0f ) volume = 0.0f;
                            // Write them to the output and bump the index.
                            output.WriteSamples(sample, 0, sample.Length);
                            ++sampleix;
                        }
                    }
                }
            }
            catch( Exception _ex )
            {
                Console.WriteLine("Exception: {0}", _ex.Message);
            }
            finally
            {
                if( output != null ) try{ output.Dispose(); } catch(Exception){}
            }
        }
    }
