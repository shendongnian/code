    public bool Load(string fileName) 
    {
        using(TextWriter tw = new StreamWriter("Appointment.txtr"))
        {
            foreach (Appointment a in this)
            {
                tw.WriteLine(a.ToString() + "\n");
            }
        }
    }
