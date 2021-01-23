    public void AddUser(User userToAdd)
    {
       SuperQquery.PersonelTable pt = new SuperQquery.PersonelTable();
       pt.FieldName1 = userToAdd.Isim;
       pt.FieldName2 = userToAdd.Soyad;
        
       entity.PersonelTable.Add(pt);
       entity.SaveChanges();
    }
