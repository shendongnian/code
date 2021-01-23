        public ICommand KeyUpFilterForUpperCaseSymbolsCommand
        {
            get
            {
                if (_keyUpFilterForUpperCaseSymbolsCommand== null)
                {
                    _keyUpFilterForUpperCaseSymbolsCommand= new RelayCommand(KeyUpFilterForUpperCaseSymbols);
                }
                return _keyUpFilterForUpperCaseSymbolsCommand;
            }
        }
...
        private void KeyUpFilterForUpperCaseSymbols(object sender)
        {
            TextBox tb = sender as TextBox;
            if (tb is TextBox)
            {
                // check for a caps character here
                // then modify tb.Text, to exclude the character.
                // Example: tb.Text = oldText.Substring(0, x);
            }
        }
 
