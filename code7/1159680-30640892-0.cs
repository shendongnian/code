    if (!CurrentUser.IsInRole("Admin"))
            {
             this.gdCustomers.Columns[2].Visible = true;
             btnDelete.Visible = false;
             btnUpload2.Visible = false;
            }
