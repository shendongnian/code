        public RelayCommand<object> TextInputCommand { get; set; }
        public bool CanExecuteTextInputCommand(object param)
        {
            return true;
        }
        public void ExecuteTextInputCommand(object param)
        {
            TextCompositionEventArgs e = param as TextCompositionEventArgs;
            string currentText = this.Text;
            string entireText = string.Format("{0}{1}", currentText, e.Text);
            var item = this.Items.Where(d => d.StartsWith(entireText)).FirstOrDefault();
            if (item == null)
            {
                e.Handled = true;
                this.Text = currentText;
            }
        }
