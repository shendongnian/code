    private void button_Click(object sender, RoutedEventArgs e)
    {
        Choice win2 = new Choice(this);
        win2.Show();
    }
    
    
    public partial class Choice : Window
    {
        Prepare parent;
    
        public Choice(Prepare parent)
        {
            this.parent = parent;
        }
    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            parent.DoStuff();
            this.Close();
        }
    }
