    public void Copy(string source, string dest)
    {
        const int updateMilliseconds = 100;
        int index = 0;
        int i = 0;
        StreamWriter writefile = null;
        try
        {
            using (StreamReader readfile = new StreamReader(source))
            {
                writefile = new StreamWriter(dest + index);
                // Initial value "back in time". Forces initial update
                int milliseconds = unchecked(Environment.TickCount - updateMilliseconds);
                string content;
                while ((content = readfile.ReadLine()) != null)
                {
                    writefile.Write(content);
                    writefile.Write("\r\n"); // Splitted to remove a string concatenation
                    i++;
                    if (i % 1000000 == 0)
                    {
                        index++;
                        writefile.Dispose();
                        writefile = new StreamWriter(dest + index);
                        // Force update
                        milliseconds = unchecked(milliseconds - updateMilliseconds);
                    }
                    int milliseconds2 = Environment.TickCount;
                    int diff = unchecked(milliseconds2 - milliseconds);
                    if (diff >= updateMilliseconds)
                    {
                        milliseconds = milliseconds2;
                        Invoke((Action)(() => label5.Text = string.Format("File {0}, line {1}", index, i)));
                    }
                }
            }
        }
        finally
        {
            if (writefile != null)
            {
                writefile.Dispose();
            }
        }
        // Last update
        Invoke((Action)(() => label5.Text = string.Format("File {0}, line {1} Finished", index, i)));
    }
