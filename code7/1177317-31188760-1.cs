    [HttpPost]
    public void AddCategorie(string cat) {
        db.Categories.Add(new Category { CategoryNom = cat });
        db.SaveChanges();
    }  
