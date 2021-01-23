        private void ButtonEn_OnClick(object sender, RoutedEventArgs e)
        {
            ApplicationLanguages.PrimaryLanguageOverride = "en-US";
            UpdateLang("en-US");
        }
        private async void UpdateLang(string newLang)
        {
            var resourceContext = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView();
            while (true)
            {
                if (resourceContext.Languages[0] == newLang)
                {
                    var loc = Application.Current.Resources["Loc"] as LanguagesManager;
                    loc.ChangeLang();
                    break;
                }
                await Task.Delay(100);
            }
        }
