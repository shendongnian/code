                    for (int oh = 0; oh < productIndexes.Count; oh++)
                    {
                        if (oh == 0)
                        {
                            filter += "(DateTime >= #" + startDateTime.ToString("MM/dd/yyyy HH:mm:ss") + "# And DateTime <= #"
                                + endDateTime.ToString("MM/dd/yyyy HH:mm:ss") + "#)" + " And (TagIndex = '" + productIndexes[oh] + "'";
                            indexFilter = "(;Tagname = '" + productIndexes[oh] + "'";
                        }
                        else
                        {
                            filter += " And (DateTime >= #" + startDateTime.ToString("MM/dd/yyyy HH:mm:ss") + "# And DateTime <= #"
                        + endDateTime.ToString("MM/dd/yyyy HH:mm:ss") + "#)" + " Or TagIndex ='" + productIndexes[oh] + "'";
                            indexFilter += " Or ;Tagname = '" + productIndexes[oh] + "'";
                        }
                    }
                    filter += " )";
                    indexFilter += " )";
                    Console.WriteLine(filter);
                    Console.WriteLine(indexFilter);
