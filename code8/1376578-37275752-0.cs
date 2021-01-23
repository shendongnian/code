    if (ofd.ShowDialog() == DialogResult.OK)
    {
        using (TextReader reader = new StreamReader(ofd.OpenFile()))
        {
            string line;
            while((line = t.ReadLine()) != null)
                Console.WriteLine(line);
        }
    }
