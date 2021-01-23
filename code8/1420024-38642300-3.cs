    public MainWindow()
            {
    
                InitializeComponent();
            }
    
            private void FillMe_OnClick(object sender, RoutedEventArgs e)
            {
                this.catSubcategory.Items.Add(new { Text = "Hello" });
                this.catSubcategory.Items.Add(new { Text = "World" });
                this.catSubcategory.Items.Add(new { Text = "Hello" });
                this.catSubcategory.Items.Add(new { Text = "Moon" });
            }
    
            private void ReadMeCat_OnClick(object sender, RoutedEventArgs e)
            {
                var result = catSubcategory.Items.Cast<dynamic>().Aggregate("", (current, xx) => (string) (current + (xx.Text + "\n")));
                MessageBox.Show(result);
            }
    
            private void ReadMeCombo_OnClick(object sender, RoutedEventArgs e)
            {
                var result = cboCategory.Items.Cast<ComboBoxItem>().Aggregate("", (current, xx) => current + (xx.Content.ToString() + "\n"));
                MessageBox.Show(result);
            }
