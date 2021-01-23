     else if (ctrc is ListBox)
                                {
                                    var selected = new List<string>();
                                    for (int i = 0; i < lstmulti.Items.Count; i++)
                                    {
    
                                        if (lstmulti.Items[i].Selected)
    
                                            selected.Add(lstmulti.Items[i].Text);
    
                                        string selectedItem = lstmulti.Items[i].Text;
                                        sres.Response = string.Join(",", selected) ;
    
                                      
                                    }
    
                                   
    
                                }
                            }
