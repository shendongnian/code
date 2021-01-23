    var SongSegments = new Dictionary<string, string[]>() {
        { "C-Maj", "C D E F G A B".Split() },
        { "G-Mag", "G A B C D E F#".Split() }, // "G-Maj"* ?
        { "D-Maj", "D E F# G A B C#".Split() }, // I like how your C# code has C# song segments :]
        { "A-Maj", "A B C# D E F# G#".Split() },
        { "E-Maj", "E F# G# A B C# D#".Split() } };
    int MaxNotes = 100;
    string SongSegment = "";
    Random NoteIndexGen = new Random();
    for (int NoteCounter = 0; NoteCounter <= MaxNotes; NoteCounter++) 
    {
        int NoteIndex = NoteIndexGen.Next(0, 6);
        SongSegment += "  " + SongSegments[Key][NoteIndex] +  "  ";
        OutputInfo1.Text = SongSegment;  
    }
