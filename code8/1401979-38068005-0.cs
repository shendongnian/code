    async void EditInfoClicked(object sender, EventArgs e)
        {
            ProfileDetailViewModel viewModel = new 
            ProfileDetailViewModel (Navigation, user);
            var profileDetailPage = new shared.MyProfilePage()
    
            {
                BindingContext = viewModel
            };
    
            await Navigation.PushAsync(profileDetailPage);
        }
