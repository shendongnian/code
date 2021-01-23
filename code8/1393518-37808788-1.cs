    public sealed partial class Meds : Page
    {
        private string DBPath { get; set; }
        public Meds()
        {
            this.InitializeComponent();
            // Create the Database
            DBPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "meds.sqlite");
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DBPath))
            {
                conn.CreateTable<Medications>();
                // Set ItemsSource to the sqlite data for ListView
                myList.ItemsSource = conn.Table<Medications>();
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DBPath))
            {
                // Add Medications
                conn.Insert(new Medications
                {
                    MedName = medname_box.Text,
                    MedDose = meddose_box.Text,
                    WhatFor = whatfor_box.Text
                });
                // Update the ItemsSource for ListView
                myList.ItemsSource = conn.Table<Medications>();
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
