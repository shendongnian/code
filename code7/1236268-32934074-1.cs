    string s = ConvertToString(new Obj
                {
                    Name = "Method",
                    Value = "And",
                    Childs = new List<Obj>
                            {
                                new Obj()
                                {
                                    Name = "Method",
                                    Value = "And",
                                    Childs = new List<Obj>
                                    {
                                         new Obj()
                                        {
                                            Name = "Operator",
                                            Value = "IsEqual",
                                            Childs = new List<Obj>
                                            {
                                               new Obj()
                                               {
                                                   Name="Name",
                                                   Value="5",
                                                   Childs=null
                                               }
                                            }
                                        },
                                        new Obj()
                                        {
                                        Name = "Operator",
                                            Value = "IsEqual",
                                            Childs = new List<Obj>
                                            {
                                               new Obj()
                                               {
                                                   Name="Name",
                                                   Value="6",
                                                   Childs=null
                                               }
                                            }
                                        }
                                    }
                                },
                                new Obj()
                                {
                                    Name = "Operator",
                                    Value = "IsEqual",
                                    Childs = new List<Obj>
                                    {
                                       new Obj()
                                       {
                                           Name="Name",
                                           Value="3",
                                           Childs=null
                                       }
                                    }
                                }
                            }
                });
