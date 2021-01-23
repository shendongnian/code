     public partial class MainWindow : Window
    {
      
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void but_MouseMove(object sender, MouseEventArgs e)
        {
            Button src=sender as Button;
            if (src != null && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(src,
                                     src.Content.ToString(),
                                     DragDropEffects.Copy);
            }
        }
        private void but_Drop(object sender, DragEventArgs e)
        {
            Button dest = sender as Button;
            string destinationContent = null; 
            destinationContent = dest.Content as string;
            if (dest != null)
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string sourceContent = (string)e.Data.GetData(DataFormats.StringFormat);
                    if (destinationContent.Equals(sourceContent))
                    {
                        Console.WriteLine("equal");
                    }
                }
            }
           
        }
       
    }
