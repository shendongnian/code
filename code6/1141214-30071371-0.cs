        using (StreamReader sr = new StreamReader(@"data.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    listBox1.Items.Add(sr.ReadLine());
                }
            }
