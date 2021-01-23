    public partial class MultipleTextBoxControl : UserControl
        {
            TextBoxData _newTextBoxGroup;
            public TextBoxData TextBoxGroup { get { return _newTextBoxGroup; } }
    
            public MultipleTextBoxControl(int identifier)
            {
                InitializeComponent();
    
                _newTextBoxGroup = new TextBoxData(identifier);            
    
            }
            
            public class TextBoxData
            {
                public int Identifier { get; set; }
                public string TextBox1Data { get; set; }
                public string TextBox2Data { get; set; }
    
                public TextBoxData(int identifier)
                {
                    Identifier = identifier;
    
                    TextBox1Data = "Unchanged Textbox 1";
                    TextBox2Data = "Unchanged Textbox 2";
                }
            }
    
            private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
            {
                _newTextBoxGroup.TextBox1Data = textBox1.Text;
            }
    
            private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
            {
                _newTextBoxGroup.TextBox2Data = textBox2.Text;
            }
        }
