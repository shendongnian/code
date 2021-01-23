    FileStream stream = new FileStream("location", FileMode.Open, FileAccess.Read);
            char actual = '\0';
            if(stream.Length != 0)
            {
                stream.Seek(-1, SeekOrigin.End);
                var lastChar = (byte)stream.ReadByte();
                actual = (char)lastChar;
            }
            stream.Close();
            try {
                if(addCompT.Text != "")
                {
                    if (actual == '\n' || actual == '\0')   
                        File.AppendAllText("location", addCompT.Text + Environment.NewLine);
                    else
                        File.AppendAllText("location", Environment.NewLine + addCompT.Text + Environment.NewLine);
                    addCompT.Text = "";
                }
                    
            }
            catch(System.UnauthorizedAccessException)
            {
                MessageBox.Show("Please Run Program As Administrator!");
            }
