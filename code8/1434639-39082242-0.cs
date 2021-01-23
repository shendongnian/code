            private async void ShowPopup()
            {
                ContentPage detailsPage = new ContentPage
                {
                    BackgroundColor = Color.Transparent,// Color.FromHex("#00F0F8FF"),
                    Padding = new Thickness(40, 40, 40, 40)
                };
                MainPage l = new MainPage();
                detailsPage.Content = l.Content;
                Button b = l.FindByName<Button>("btnClose");
                b.Clicked += ((o2, e2) =>
                {
                    this.Navigation.PopModalAsync();
                });
                await Navigation.PushModalAsync(detailsPage, false);
            }
