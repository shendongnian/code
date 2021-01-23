    public bool Load(string fileName) 
    {
        TextWriter tw = new StreamWriter("Appointment.txtr");
        foreach (string s in this)
        {
            tw.WriteLine(s + "\n");
        }
    }
