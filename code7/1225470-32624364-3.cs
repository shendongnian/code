    public partial class MainWindow : Window
        {
            int MultipleTextBoxControlID = 1;
            public static List<MultipleTextBoxControl.TextBoxData> MasterDataList;
    
            static MainWindow() {
                MasterDataList = new List<MultipleTextBoxControl.TextBoxData>();
            }
    
            public MainWindow()
            {
                InitializeComponent();
            }
           
    
            private void CreateNewControl_Click(object sender, RoutedEventArgs e)
            {
                MultipleTextBoxControl newUserControl = new MultipleTextBoxControl(MultipleTextBoxControlID);
                UserControlContainer.Children.Add(newUserControl);
    
                MasterDataList.Add(newUserControl.TextBoxGroup);
            }
    
            private void GiveStringFromList_Click(object sender, RoutedEventArgs e)
            {
                foreach (MultipleTextBoxControl.TextBoxData textBoxPanel in MasterDataList)
                {
                    List<string> userControlLine = new List<string>();
    
                    userControlLine.Add(textBoxPanel.Identifier.ToString());
                    userControlLine.Add(textBoxPanel.TextBox1Data);
                    userControlLine.Add(textBoxPanel.TextBox2Data);
    
                    MessageBox.Show(string.Join(",", userControlLine));
                }
            }
        }
