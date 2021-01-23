      private void SaveChanges_Click(object sender, RoutedEventArgs e) 
      {
            using (var db = new Family())
            {
                db.SaveChanges();
            }
      }
