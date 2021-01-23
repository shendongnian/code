    string[] properties = new string[]{"FirstName","LastName"};
    foreach(var property in properties){        
        object value = userToUpdateWith.GetType().GetProperty(property).GetValue(userToUpdateWith, null); 
        userToUpdate.GetProperty(property).SetValue(userToUpdate, value, null);       
    
    c2.SaveChanges();
