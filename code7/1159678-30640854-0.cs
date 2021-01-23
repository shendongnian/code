     if (!CurrentUser.IsInRole("Admin"))
     {
         this.dgCustomers.Columns[4].Visible = false;
         btnDelete.Visible = false;
         btnUpload2.Visible = false;
     }
