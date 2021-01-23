    var listitems = list.Select(l => { var li = new ListItem
                                {
                                    Value = l.Id,
                                    Text = l.Description
                                    
                                }; li.Attributes.Add(....); return li; ).ToList();
