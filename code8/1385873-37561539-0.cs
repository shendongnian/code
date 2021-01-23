     private void addNewClient(object sender, EventArgs e)
            {
                AddClient frmAdd = new AddClient();
                frmAdd.ShowDialog(); //form that returns a valid Client
                using (db = new FacturationAppContext())
                {
                    if (frmAdd.newClient != null)
                    {
                        db.Clients.Add(frmAjouter.newClient);
                        db.SaveChanges();
                    }
                }
    
            }
