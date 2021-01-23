    using (SampleEntities se = new SampleEntities())
    {
       Customer c = new Customer();
       c.Id = FindNextId();
       c.Age = Convert.ToDouble(txtAge.Text);
       c.Name = txtAge.Text;
       se.AddToCustomers(c);
       se.SaveChanges();
    }
    MessageBox.Show("Done");
