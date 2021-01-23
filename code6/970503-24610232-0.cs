     public void RemoveFromClientList(string ClientName)
    {
       
            var toRemove =listView1.Items.Find(ClientName);
            if (toRemove != null)
            {
               listView1.Items.Remove(toRemove);
            }
     
    }
