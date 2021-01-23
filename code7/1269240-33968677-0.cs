            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;
                string fn = ofd.FileName;
                string[] lines = File.ReadAllLines(fn);
                txtData.Text = "";
                List<string> Clean = new List<string>(lines);
                for (int i = 0; i < 3; i++)
                {
                    Random rnd = new Random(DateTime.Now.Millisecond);
                    int index = rnd.Next(0, Clean.Count);
                    if (Clean[index].Contains(","))
                    {//Already has noise.
                        i--;
                    }
                    else
                    {//Make some noise.
                        Clean[index] = Clean[index] + "," + i.ToString();
                    }
                }
                //Clean.ForEach(var => Console.WriteLine(var));
                // Console.WriteLine();
                // Console.ReadLine();
                for (int i = 0; i < Clean.Count; i++)
                {
                    txtData.Text += Clean[i] + Environment.NewLine;
                }
            }
