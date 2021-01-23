        protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MyViewModel mvm = this.DataContext as MyViewModel;
            mvm.MyCommand.Execute();
        }
