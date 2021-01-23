    protected void btnFinalizeSO_Click(object sender, EventArgs e)
    {
        using(MyDataBaseEntities db = new MyDataBaseEntities())
       {
           Number lastNumber = (from c in db.Number orderby IDNumber select c).LastOrDefaul();
           foreach(var item in ListBoxSO.Items)
           {
              
                Number n = new Number();
                n.IdNumber = lastNumber.IdNumber +1; 
                n.Id = lastNumber.Id + 1;
                n.Name = ListBoxSO.GetItemText(item);
                db.Number.Add(n);
           }
          db.SaveChanges();
       }
    }
    
