    XDocument xdoc = XDocument.Load("file_path_here");
                    List<xElement> covers = xDoc.XPathSelectElements("/songCover/item").ToList();
                    List<xElement> names = xDoc.XPathSelectElements("/songName/item").ToList();
                    List<xElement> years = xDoc.XPathSelectElements("/releaseYear/item").ToList();
                    for (int i = 0; i < covers.Count; i++)
                    {
                        Console.WriteLine("[ " + covers[i].Value + ", " + names[i].Value + ", " + years[i].Value + " ]");
                    }
