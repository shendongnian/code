            List<string> lines = new List<string>(textBox1.Lines);
            for(int i = 0; i < lines.Count; i++)
            {
                // check for some condition
                if (lines[i].StartsWith("Di"))
                {
                    // modify the line somehow
                    lines[i] = lines[i] + ", " + textBox2.Text;
                    break; // optionally break?...or modify other lines as well?
                }
            }
            textBox1.Lines = lines.ToArray(); // update the textbox with the new lines
