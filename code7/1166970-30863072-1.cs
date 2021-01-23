        public void OnNextClicked(object sender, EventArgs args)
        {
            NavigationService.NavigateTo(new Window2());
        }
        public void OnPreviousClicked(object sender, EventArgs args)
        {
            NavigationService.NavigateBack();
        }
