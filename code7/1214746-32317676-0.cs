        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string parameter = this.NavigationContext.QueryString["parameter"];
            BaseViewModel.SelectedCommentID = parameter;
        }
        private async void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this.repliesViewModel;
            await repliesViewModel.GetReplyList();
            //lbxReplies.ItemsSource = null; *removed*
            //lbxReplies.ItemsSource = repliesViewModel.ReplyList;
        }
