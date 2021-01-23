        private void setUpContacts(Establishment establishment)
        {
            foreach(Contact contact in establishment.Contacts)
            {
                StackLayout row = new StackLayout
                {
                    Orientation = StackOrientation.Vertical
                };
                row.Children.Add(new Label
                {
                    TextColor = Color.Gray,
                    Text = string.Format("{0}:", contact.StringType)
                });
                row.Children.Add(new Label
                {
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold,
                    Text = contact.Value,
                });
                row.GestureRecognizers.Add(new TapGestureRecognizer {
                    Command = new Command(() => OnContactTapped(row, contact))
                });
                ContactsList.Children.Add(row);
            }
        }
