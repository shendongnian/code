    Db.Templates.Add(newItem);
    foreach (var record in variable.Where(record => record.Name == newItem.Name))
        {
             record.Templates.Add(newItem);
        }
                    
    }
    Db.SaveChanges();
