     <RichTextBox x:Name="rtb" Width="200" Height="200" PreviewTextInput="rtb_PreviewTextInput"/>
     public partial class MainWindow : Window
    {
        string prevText=string.Empty;
        TextPointer start;
        public MainWindow()
        {
            InitializeComponent();            
        }      
        private void rtb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Equals("*") && (prevText.Equals("/")))
            {
                start = rtb.CaretPosition;
                TextPointer end = rtb.Document.ContentEnd;
                TextRange range = new TextRange(start, end);
                range.ApplyPropertyValue(RichTextBox.ForegroundProperty, Brushes.Green);
            }
            if (e.Text.Equals("/") && (prevText.Equals("*")))
            {                
                TextPointer end = rtb.CaretPosition; 
                TextRange range = new TextRange(start, end);
                range.ApplyPropertyValue(RichTextBox.ForegroundProperty, Brushes.Red);
            }
            prevText = e.Text;
        }        
    }
