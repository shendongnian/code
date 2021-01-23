    private void ltbxAvailableCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Car temp = (Car)ltbxAvailableCars.SelectedItem;
        Int32 id = temp.ID
        CarRentalDBEntities db = new CarRentalDBEntities();
        var query = from c in db.Cars
                    where c.ID == id
                    select new
                    {
                        c.ID,
                        c.Make,
                        c.Model,
                        c.Size
                    };
        tblkSelectedCarDetails.Text = query.ToString();
    }
