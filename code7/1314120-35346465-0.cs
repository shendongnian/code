    using (FileStream fs = File.Create(path))
    {
            richTextBox1.Clear();
            pathString = System.IO.Path.Combine(@"c:\Tvarkarastis", "Tvarkarastis.txt");
            string[] lines = { "First line", "Second line", "Third line" };
            richTextBox1.AppendText("Prašome atsidaryti failą ir jį pakeisti. Failas yra : " + pathString + Environment.NewLine);
            System.IO.File.WriteAllLines(pathString, lines);
    }
