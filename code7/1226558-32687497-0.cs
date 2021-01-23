    private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var dbpath = ApplicationData.Current.LocalFolder.Path + "/Mydb1.db";
           
            var con = new SQLiteAsyncConnection(dbpath);
            if (list_view.SelectedItem != null)
            {
                list k = (list)list_view.SelectedItem;
               await con.QueryAsync<list>("delete from list where list1='" + k.list1 + "'");
                update();
            }
     public async void update()
        {
            var dbpath = ApplicationData.Current.LocalFolder.Path + "/Mydb1.db";
            var con = new SQLiteAsyncConnection(dbpath);
            list_view.ItemsSource = new List<list>();
            List<list> mylist = await con.QueryAsync<list>("select * from list");
            if (mylist.Count != 0)
            {
                list_view.ItemsSource = mylist;
                list_view.DisplayMemberPath = "list1";
            }
        }
