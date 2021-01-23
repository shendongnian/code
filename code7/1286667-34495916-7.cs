    private void Add_Click(object sender, RoutedEventArgs e)
    {
            using (var db = new Family())
            {
                var ft = new Father { Name = NewFT.Text };
                db.Fathers.Add(ft);
                db.SaveChanges();
                Fathers.ItemsSource = db.Fathers.ToList();
            }
     }
