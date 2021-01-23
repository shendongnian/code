    if (!CurrentUser.IsInRole("Admin"))
            {
             this.gdCustomers.Columns[2].Visible = false;
             btnDelete.Visible = false;
             btnUpload2.Visible = false;
            }
