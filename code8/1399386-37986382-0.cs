     protected void Save(object sender, EventArgs e)
    {
        using (var context = new EntityModelNAme())
            {
                int Pid = Convert.ToInt32(Label13.Text);// Get your Primary Id value
                DBTableName Obj = (from c in context.DBTableName
                                   where c.ID == Pid
                                   select c).FirstOrDefault();// Match the Id with Database
                Obj.Type =  typetxt.Text;           
                Obj.Model = modeltxt.Text;
                Obj.Quant = quantxt.Text;
                // Like Above write your code
                context.SaveChanges();           
            }
            this.BindGrid();
    }
