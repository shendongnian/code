    ddmenu_Home.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(() =>
                    {
                        ddmenu_Home.IsEnabled = false;
                        await Navigation.PushAsync(new MainPage());
                        ddmenu_Home.IsEnabled = true;
                    })
                });
