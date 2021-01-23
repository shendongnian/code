    private async void ShowPopup()
        {
            //Create `ContentPage` with padding and transparent background
            ContentPage loginPage = new ContentPage
            {
                BackgroundColor = Color.FromHex("#D9000000"),
                Padding = new Thickness(20, 20, 20, 20)
            };
            // Create Children
            //Create desired layout to be a content of your popup page. 
            var contentLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Children =
                        {
                            // Add children
                        }
            };
            //set popup page content:
            loginPage.Content = contentLayout;
            //Show Popup
            await Navigation.PushModalAsync(loginPage, false);
        }
