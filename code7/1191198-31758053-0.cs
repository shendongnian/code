       public bool LoadMidi(string file, bool UnloadUnusedInstruments)
    {
        MidiFile mf = File.Open(file, FileMode.Open);
    return LoadMidi(mf, UnloadUnusedInstruments);
    }
