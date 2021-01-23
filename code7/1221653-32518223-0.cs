    IList<string> output = new List<string>();
    using (StreamReader sr = new StreamReader("d:\\data\\test.txt"))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            if (line.StartsWith("Location=\""))
            {
                line = String.Format("Location=\"{0}\"", "TextBox.Text");
            }
            output.Add(line);
        }
    }
    File.WriteAllText("d:\\data\\test.txt", string.Join(Environment.NewLine, output));
