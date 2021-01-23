        private void Button_Click( object sender, RoutedEventArgs e ) { Task.Run( () => Authenticate() ); }
        public void Authenticate()
        {
            Dispatcher.Invoke(
                () =>
                {
                    ClickButton.Content = "Text Changed";
                } );
        }
