    try
    {  
                DbContext xyz = new DbContext();
                Store oStore = new Store();
                oStore.Item = "pen";
                oStore.Description = "blue";
                oStore.Expences = 10;
                xyz.Stores.Add(oStore);
                xyz.SaveChanges(); // never forgot to do SaveChanges  
    }
    catch(Exception ex)
    {
           MessageBox.Show(ex.Message);
    }
