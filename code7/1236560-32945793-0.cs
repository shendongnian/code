    using (StreamReader sr = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + pageName + ".designer.cs"))
                {
                    String line = "";
    
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(';'))
                        {
                            String[] tab = line.Split(' ');
                            String nomSplit = tab[tab.Length - 1].Split(';')[0];
    
                            this.listeControls.Items.Add(new ListItem(nomSplit, nomSplit));
                        }
                    }
                }
