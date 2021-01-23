      void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UserViewModel VM = new UserViewModel();
            this.DataContext = VM;
            myFrame.Content = new MainPage();      
        }
