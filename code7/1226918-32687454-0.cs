     public async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dbpath = ApplicationData.Current.LocalFolder.Path + "/Mydb1.db";
            var con = new SQLiteAsyncConnection(dbpath);
            try
            {
                
                list l = new list();
                l.list1 = text_input.Text;
                await con.InsertAsync(l);
                update();
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
