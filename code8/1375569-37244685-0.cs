        foreach (var filePath in Directory.EnumerateFiles(@"c:\folder"))
        {
            using (var reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();
                listBox.Items.Add(line + Environment.NewLine);
            }
        }
