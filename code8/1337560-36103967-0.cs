     public partial class NewTAX : Window
        {
            ArtEntities db;
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                db = new ArtEntities();
                dbgrid.ItemsSource = db.TAXs.ToList();
            }
