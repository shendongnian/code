     private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var dbpath = ApplicationData.Current.LocalFolder.Path + "/Mydb1.db";
           
            var con = new SQLiteAsyncConnection(dbpath);
            if (list_view.SelectedItem != null)
            {
                list k = (list)list_view.SelectedItem;
               await con.QueryAsync<list>("delete from list where list1='" + k.list1 + "'");
                update();}
