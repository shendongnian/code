                    else
                    {
                        ((ListView)sender).SelectedItem = null;
                        if (OnSelectedCity != null)
                        {
                            OnSelectedCity((City)e.SelectedItem, null);
                        }
                        await Navigation.PopAsync();
                    }
