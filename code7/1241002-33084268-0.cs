            using (var reader = File.OpenText("c:\file.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!listBox.Items.Contains(line))
                        listBox.Items.Add(line);
                }
            }
