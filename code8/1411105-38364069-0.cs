    var SongSegments = new Dictionary<string, string[]>() {
        { "C-Maj", "C D E F G A B".Split() },
        { "G-Mag", "G A B C D E F#".Split() }, // "G-Maj"* ?
        { "D-Maj", "D E F# G A B C#".Split() }, // I like how your C# code has C# song segments :]
        { "A-Maj", "A B C# D E F# G#".Split() },
        { "E-Maj", "E F# G# A B C# D#".Split() } };
    int NoteCounter = 0;
    int MaxNotes = 100;
    string SongSegment = "";
    Random NoteIndexGen = new Random();
    while (NoteCounter <= MaxNotes) {
        int NoteIndex = NoteIndexGen.Next(0, 6);
        if (SongSegments.ContainsKey(Key))
        {
            SongSegment += "  " + SongSegments[Key][NoteIndex] +  "  ";
            OutputInfo1.Text = SongSegment; 
        }
        NoteCounter++;
    }
