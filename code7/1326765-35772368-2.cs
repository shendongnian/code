    private void btnMigrate_Click(object sender, EventArgs e)
        {
            if (this.f2 == null || this.f2.isDisposed == true)
            {
               f2 = new form2();
               f2.f1 = this; // this is the reference from f2 to f1
            }
            f2.Show(); // Shows Form2
            this.Hide(); //this will hide the f1, but not close it
        }
