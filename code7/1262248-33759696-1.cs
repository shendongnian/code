        public int Property2 { get; set; }
        public void ShowThis(int parameter)//Gets called by your MainWindow
        {
            this.Property2 = parameter;
            this.Show();
        }
