        public MyPageConstructor() // Your page constructor
        {
            this.DataContext = new RepliesViewModel(); // Or any other way how you create your view model
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string parameter = this.NavigationContext.QueryString["parameter"];
            BaseViewModel.SelectedCommentID = parameter;
        }
        private async void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            await repliesViewModel.GetReplyList();
            //this.DataContext = this.repliesViewModel;
            //lbxReplies.ItemsSource = null; *removed*
            //lbxReplies.ItemsSource = repliesViewModel.ReplyList;
        }
