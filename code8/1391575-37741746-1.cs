    public void LogKeyEvent(Keys  e)
    {
        listBox1.Items.Add(e);
        using(StreamWriter sw = new StreamWriter(@"d:\Prova.txt", true))
        {
             sw.Write(e);
             sw.Close();
        }
    }
