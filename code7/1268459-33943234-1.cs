    public partial class Form2 : Form
    {        
        Data Data1 {get; set;}
        //Instead of Data you can pass Form1 class as parametr. 
        //But this might lead to unreadable code, and using too mutch methods and fields that could be private, public
        public Form2(Data data)
        {
            InitializeComponent();
            Data1 = data;
        }
    
        private void buttonOpenForm3 _Click(object sender, EventArgs e)
        {
            //Repeat pattern
            Form3 frm3 = new Form3(Data1);
            frm3.Show();
        }    
    }
