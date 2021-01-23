    static int GetPianoKey(string note)
    {
        int key = -1;
        switch (note[0])
        {
            case 'A': key = 1; break;
            case 'B': key = 3; break;
            case 'C': key = 4; break;
            case 'D': key = 6; break;
            case 'E': key = 8; break;
            case 'F': key = 9; break;
            case 'G': key = 11; break;
        }
        if (note.Length == 2)
        {
            return key + 12*(note[1] - '0');
        }
        if (note.Length == 3)
        {
            return key + 12*(note[2] - '0') + (note[1] == 'b' ? -1 : 1);
        }
        throw new ApplicationException("Wrong note.");
    }
    static int GetNoteFrequency(string note)
    {
        return (int) (Math.Pow(1.05946309436, GetPianoKey(note) - 49)*440);
    }
    static int GetTickDuration(int tempo)
    {
        return 60000/tempo;
    }
    private static void Main(string[] args)
    {
        int duration = GetTickDuration(120); // 60 bpm. duration for quarter note
        for (int i = 0; i < 2; i++)
        {
            Console.Beep(GetNoteFrequency("A3"), duration/2); // eighth note ==> duration/2
            Console.Beep(GetNoteFrequency("B3"), duration/2);
            Console.Beep(GetNoteFrequency("C3"), duration/2);
            Console.Beep(GetNoteFrequency("D3"), duration/2);
            Console.Beep(GetNoteFrequency("E3"), duration / 2);
            Console.Beep(GetNoteFrequency("C3"), duration / 2);
            Console.Beep(GetNoteFrequency("E3"), duration / 2);
            Task.Delay(duration/2).Wait(); //  eighth rest ==> duration/2
            Console.Beep(GetNoteFrequency("D#3"), duration / 2);
            Console.Beep(GetNoteFrequency("B3"), duration / 2);
            Console.Beep(GetNoteFrequency("D#3"), duration / 2);
            Task.Delay(duration / 2).Wait();
            Console.Beep(GetNoteFrequency("D3"), duration / 2);
            Console.Beep(GetNoteFrequency("Bb3"), duration / 2);
            Console.Beep(GetNoteFrequency("D3"), duration / 2);
            Task.Delay(duration / 2).Wait();
            Console.Beep(GetNoteFrequency("A3"), duration / 2);
            Console.Beep(GetNoteFrequency("B3"), duration / 2);
            Console.Beep(GetNoteFrequency("C3"), duration / 2);
            Console.Beep(GetNoteFrequency("D3"), duration / 2);
            Console.Beep(GetNoteFrequency("E3"), duration / 2);
            Console.Beep(GetNoteFrequency("C3"), duration / 2);
            Console.Beep(GetNoteFrequency("E3"), duration / 2);
            Console.Beep(GetNoteFrequency("A4"), duration / 2);
            Console.Beep(GetNoteFrequency("G3"), duration / 2);
            Console.Beep(GetNoteFrequency("E3"), duration / 2);
            Console.Beep(GetNoteFrequency("C3"), duration / 2);
            Console.Beep(GetNoteFrequency("E3"), duration / 2);
            Console.Beep(GetNoteFrequency("G3"), duration * 2); // half note ==> duration*2
        }
    }
