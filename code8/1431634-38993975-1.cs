                    var data = from n in db.client
                              
                               select new ClientView()
                               {
                                   ClientId = n.ClientId ,
                                   LastName = n.LastName ,
                                   FirstName = n.FirstName,
    
                               };
                   var data1 = from n in db.client
                              
                               select new ClientView()
                               {
                                   ClientId = n.ClientId ,
                                   LastName = n.LastName ,
                                   FirstName = n.FirstName,
    
                               };
                    lst.AddRange(data);
                    lst.AddRange(data1);
    
    List<ClientView> lst1 = new List<ClientView>();
                    foreach (var singlelst in lst)
                    {
    
                        ClientView newClient = new ClientView ();
                        newClient.Id = singlelst.Id;
                        newClient.આપેલ = singlelst.LastName;
                        newClient.આપેલતારીખ = singlelst.FirstName;
                        lst1.Add(newClient);
                    }
