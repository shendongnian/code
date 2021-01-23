    charList.Items.AddRange(Process.GetProcessesByName("Tibia").ToList()
                            .Distinct().ToList() // Distinct eliminates charlist lookup
                            .ConvertAll<string>(c =>
                            {
                                int dashloc = c.MainWindowTitle.IndexOf("-")
                                return (dashloc > -1)
                                    ? c.MainWindowTitle.Substring(dashloc+1).Trim()
                                    : c.MainWindowTitle;
                            }));
    
