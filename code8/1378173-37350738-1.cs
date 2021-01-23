    CityClick.Clicked += async (sender, e) =>
                {
                    Cities page = new Cities();
                    page.OnSelectedCity += Page_OnSelectedCity;
                    await Detail.Navigation.PushAsync(page);
                };
