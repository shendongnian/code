     using (TutorBrainsDBEntities2 tB = new TutorBrainsDBEntities2())
     {
     var cl = new Client();
     cl.ClientFirstName  "XXXXX";
     cl.ClientLastName = "XXXXX";
     tB.Clients.Add(cl); //Add this line to add your newly created clients to the collection
     tB.SaveChanges();
     }
