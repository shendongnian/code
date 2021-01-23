        //your wav streams
        MemoryStream wavNoHeader1=new MemoryStream();
        MemoryStream wavNoHeader2 = new MemoryStream();
            
        //result WAV stream
        MemoryStream wav=new MemoryStream();
        //create & write header
        ushort numchannels = 1;
        ushort samplelength = 1; // in bytes
        uint samplerate = 22050;
        int wavsize = (int) ((wavNoHeader1.Length + wavNoHeader2.Length)/(numchannels*samplelength));
        BinaryWriter wr = new BinaryWriter(wav);
        wr.Write(Encoding.ASCII.GetBytes("RIFF"));
        wr.Write(36 + wavsize);
        wr.Write(Encoding.ASCII.GetBytes("WAVEfmt "));
        wr.Write(16);
        wr.Write((ushort)1);
        wr.Write(numchannels);
        wr.Write(samplerate);
        wr.Write(samplerate * samplelength * numchannels);
        wr.Write(samplelength * numchannels);
        wr.Write((ushort)(8 * samplelength));
        wr.Write(Encoding.ASCII.GetBytes("data"));
        wr.Write(numsamples * samplelength);
            
        //append data from raw streams
        wavNoHeader1.CopyTo(wav);
        wavNoHeader2.CopyTo(wav);
        //play
        wav.Position = 0;
        SoundPlayer sp=new SoundPlayer(wav);
        sp.Play();
