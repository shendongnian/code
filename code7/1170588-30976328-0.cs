    row["Total"] = months.Sum(kv =>
                                {
                                    double toReturn = 0;
                                    if (Double.TryParse(kv.Value, out toReturn ) 
                                    {
                                        return toReturn;
                                    }
                                    else
                                    {
                                        return 0;
                                    }
                                });
