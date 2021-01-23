    string OutputKSZ = "<address source=\">" +
                                    "<streetName language=\"EN\">1</streetName> " +
                                    "<streetName language=\"EN\">12</streetName> " +
                                    "<streetName language=\"EN\">111</streetName> "
                                    ;
    
                //Moved for scoping purposes
                List<string> ListKSZGedeelteStraat = new List<string>();
    
                if (OutputKSZ.Contains("<address source=\""))
                {
                    // LIJST MET START INDEXES
                    List<int> indexesStart = new List<int>();
                    var AddressSourceStart = new Regex("<streetName language=\"EN\">");
                    foreach (Match match in AddressSourceStart.Matches(OutputKSZ))
                    {
                        indexesStart.Add(match.Index);
                    }
    
                    // LIJST MET END INDEXES
                    List<int> indexesEnd = new List<int>();
                    var AddressSourceEnd = new Regex("</streetName>");
                    foreach (Match match in AddressSourceEnd.Matches(OutputKSZ))
                    {
                        indexesEnd.Add(match.Index);
                    }
    
                    int[] counterI = Enumerable.Range(0, indexesStart.Count).ToArray();
                    foreach (int i in counterI)
                    {
                        int KSZGedeelteStraatStart = indexesStart[i];
                        int KSZGedeelteStraatEnd = indexesEnd[i];
                        int KSZGedeelteStraatLength = KSZGedeelteStraatEnd - KSZGedeelteStraatStart - 26;
                        string KSZGedeelteStraat = OutputKSZ.Substring(KSZGedeelteStraatStart + 26, KSZGedeelteStraatLength);
    
                        //Remove additional foreach loop - you were adding too many times
                        ListKSZGedeelteStraat.Add(KSZGedeelteStraat);
                    }
    
                    //Assign data source once
                    comboBox2.DataSource = ListKSZGedeelteStraat;
                }
