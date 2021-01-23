        public event Action<string> UpdateText;
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
           // Access the TextBlock in UserControl2 and Change its Text to "Hello World"
           if (UpdateText != null)
               UpdateText("HelloWorld");
        }
