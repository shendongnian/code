      ResourceDictionary r1;
      ResourceDictionary r0;
        public MainWindow()
        {
            InitializeComponent();
            r1 = this.Resources.MergedDictionaries[1];
            r0 = this.Resources.MergedDictionaries[0];
            this.Resources.MergedDictionaries.Remove(r1);
       
        }
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            this.Resources.Clear();
            if (Radiobtn.IsChecked == true)
            {
                this.Resources.MergedDictionaries.Add(r0);
            }
            else
            {
                this.Resources.MergedDictionaries.Add(r1);
            }
        }
