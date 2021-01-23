    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
            using (var db = new Family())
            {
                db.Fathers.Load();
                Fathers.ItemsSource = db.Fathers.Local;
                db.Sons.Load();
                Sons.ItemsSource = db.Sons.Local;
                FT.ItemsSource = db.Fathers.Local;
            }
    }
