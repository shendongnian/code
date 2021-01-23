        private void YourUIConstructor()
        {
            MyLogic += OnContactAdded;
        }
        private void OnContactAdded(object sender, ModelAddedEventArgs<Contact> e)
        {
            Contacts.Add(e.NewModel);
        }
