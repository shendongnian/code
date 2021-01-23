    public partial class Window2 : Window
        {
            public Window2(int Id)
            {
                InitializeComponent();
                ReadDataFromDB(Id);
            }
    
            public void ReadDataFromDB(int Id)
            {
    
                //read your data
                txtBox1.Text = "Some value 1";
                txtBox2.Text = "Some value 2";
                txtBox3.Text = "Some value 3";
                txtBox4.Text = "Some value 4";
            }
        }
