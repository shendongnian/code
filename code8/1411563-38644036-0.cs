       private void ChangeLanguage(object sender, SelectionChangedEventArgs e)
        {
            var newlySelected = e.AddedItems[0] as ComboBoxItem;
            string newLanguage = newlySelected.Content.ToString();
            switch (newLanguage)
            {
                case "English":
                    {
                        CultureInfo.CurrentCulture = new CultureInfo("en");
                        CultureInfo.CurrentUICulture = new CultureInfo("en");
                        break;
                    }
                case "Spanish":
                    {
                        CultureInfo.CurrentCulture = new CultureInfo("es");
                        CultureInfo.CurrentUICulture = new CultureInfo("es");
                        break;
                    }
                case "French":
                    {
                        CultureInfo.CurrentCulture = new CultureInfo("fr");
                        CultureInfo.CurrentUICulture = new CultureInfo("fr");
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("Unidentified Language");
                    }
            }
        }
