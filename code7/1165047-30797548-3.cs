    public class Form2
    {
         public Form2()
         {
            InitializeComponent();
            //Default Consturctor
         }
         private DataTable LocalData;
         public Form2(DataTable Data)
         {
            InitializeComponent();
            LocalData = Data;
         }
         public void Form2_Load(object sender, EventArgs e)
         {
                  //Consume LocalData Here
         }
    }
