       if (ModelState.IsValid)
          {
          string _name =_col["Name"].ToString();
          string _anotherField =_col["anotherField"].ToString();
    
          TbleUser newUser = new TbleUser(){
             name = _name 
             anotherField  = _anotherField 
          };
         
          db.tbl_User.Add(newUser);
          db.SaveChanges();
          return RedirectToAction("Index");
 
