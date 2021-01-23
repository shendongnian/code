            FileInfo file = new FileInfo(txtExisting.Text + ".txt");
            if (!File.Exists(file.FullName))
            {
                Console.WriteLine("File Not Found!");
            }
            else
            {
                StreamReader stRead = file.OpenText();
                while (!stRead.EndOfStream)
                {
                    lenter code hereistBox1.Items.Add(stRead.ReadLine());
                }
            }
