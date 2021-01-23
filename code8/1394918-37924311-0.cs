    for (int h = 0; h < myHeader2.Count; h++ )
                {
                    if (myHeader2[h].PreviousSibling().InnerXml.ToLower().Contains("heading4"))
                    {
                        myHeaderX = myHeader2[h].Select(p => p.Parent).Distinct().ToList();
                        myHeader3.AddRange(myHeaderX.Select(p => p.PreviousSibling()).Distinct().ToList());
                    }
                    if (myHeader2[h].PreviousSibling().InnerXml.ToLower().Contains("heading3"))
                    {
                        myHeaderX = myHeader2[h].Select(p => p.Parent).Distinct().ToList();
                        myHeader3.AddRange(myHeaderX.Select(p => p.PreviousSibling()).Distinct().ToList());
                    }
                    else if(myHeader2[h].PreviousSibling().InnerXml.ToLower().Contains("author"))
                    {   
                        myHeaderX = myHeader2[h].Select(p => p.Parent).Distinct().ToList();
                        var x = myHeaderX;
                        for (int ed = 0; ed < 100; ed++)
                        {
                            var y = x.Select(p => p.PreviousSibling()).Distinct().ToList();
                            x = y;
                            myHeader3.AddRange(y);
                            IEnumerable<Boolean> z = y.Select(p=>p.PreviousSibling().InnerXml.ToLower().Contains("author"));
                            if(z.First())
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                foreach (OpenXmlElement ele in myHeader3 )
                {
                    if (ele.PreviousSibling().InnerXml.ToLower().Contains("heading4"))
                    {
                        myHeaderX1 = ele.Select(p => p.Parent).Distinct().ToList();
                        myHeaders.AddRange(myHeaderX1.Select(p => p.PreviousSibling()).ToList());
                    }
                    else if (ele.PreviousSibling().InnerXml.ToLower().Contains("heading3"))
                    {
                        if (ele.InnerXml.ToLower().Contains("heading4"))
                        {
                            continue;
                        }
                        myHeaderX1 = ele.Select(p => p.Parent).Distinct().ToList();
                        myHeaders.AddRange(myHeaderX1.Select(p => p.PreviousSibling()).Distinct().ToList());
                    }
                }
    
