    public void LogKeyEvent(Keys  e)
    {
        listBox1.Items.Add(e.KeyCode);
        using(StreamWriter sw = new StreamWriter(@"d:\Prova.txt", true))
        {
             sw.Write(e.KeyCode);
             sw.Close();
        }
    }
