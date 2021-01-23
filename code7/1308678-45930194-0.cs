                IPropertySet roamingProperties = ApplicationData.Current.RoamingSettings.Values;
                if (!roamingProperties.ContainsKey("DisclaimerAccepted"))
                {
                    var dialog = new MessageDialog(strings.Disclaimer);
                    dialog.Title = "Disclaimer";
                    dialog.Commands.Clear();
                    dialog.Commands.Add(new UICommand { Label = "Accept", Id = 0 });
                    dialog.Commands.Add(new UICommand { Label = "Decline", Id = 1 });
                    var result = await dialog.ShowAsync();
                    if ((int)result.Id == 1)
                        Application.Current.Exit();
                    roamingProperties["DisclaimerAccepted"] = bool.TrueString; 
                }
