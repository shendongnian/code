    List<Planets> Planets = new List<Planets>();
                            using (StreamReader sr = new StreamReader(args[0]))
                            {
                                String line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    Planets planet = new Planets();
                                    String[] parts = line.Split('|');
                                    planet.Number = Convert.ToInt32(parts[0]);
                                    planet.name = parts[1];
                                    planet.obj = parts[2];
    
                                    String[] smallerParts = parts[3].Split(';');
                                    planet.proportion = new List<proportion>();
                                    foreach (var item in smallerParts)
                                    {
                                        proportion prop = new proportion();
                                        prop.Number =                                    
                                        Convert.ToInt32(item.Split(':')[1]);
                                        planet.proportion.Add(prop);
                                    }
                                    Planets.Add(planet);
                                }
                            }
