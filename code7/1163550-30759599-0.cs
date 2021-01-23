    private void AddUser()
    {
        using (var context = new AzubiTestEntities())
        {
            var user = new Benutzer();
            var gruppen = context.Gruppen.First(x => x.GruppenID == [group id]);
            user.Name = Username;
            user.Passwort = GenerateHashPassword();
            
            user.Gruppen = gruppen;
            user.Anlegedatum = DateTime.Now;
            user.Loeschdatum = null;
            user.ErstellerID = 1;
            context.Benutzer.Add(user);
            context.SaveChanges();
        }
    }
