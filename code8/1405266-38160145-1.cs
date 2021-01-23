    string hello = Properties.Resources.hello;
    Random rand = new Random();
    IEnumerable<string> lines = hello.Split(new[] { Environment.NewLine }, 
                                    StringSplitOptions.RemoveEmptyEntries).ToList();
    var lineToRead = rand.Next(1, lines.Count());
    var line = lines.Skip(lineToRead - 1).First();
    txtbx_output.Text = line.ToString();
