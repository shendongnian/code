     public string getName(string username, string password)
             {
                 var user = db.users.Where(m => m.username == username && m.pwd == password);
                 if (user.ToList().Count <= 0)
                     return "";
                 else {
                     var client= db.clients.Where(m => m.credenziali == user.First().id);
                     return (client.First().name + client.First().surname);
                 }
