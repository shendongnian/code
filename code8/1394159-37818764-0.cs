    private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            DBPath2 = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "meds.sqlite");
            using (SQLite.Net.SQLiteConnection conn2 = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DBPath2))
            {
    // **This as where the error was**
                var existingconact = conn2.Query<Medications>("select * from Medications where **Id = Id"**).FirstOrDefault();
                if (existingconact != null)
                {
                    conn2.RunInTransaction(() =>
                       {
                           conn2.Delete(existingconact);
                       });
                    myList.ItemsSource = conn2.Table<Medications>();
                }
            }
        }
    }
}
