        public partial class Form2 : Form
        {
            private double ID=0;
            public Form2()
            {
                  InitializeComponent();
            }
            protected void Page_Load(object sender, EventArgs e)
             {
             double ID = 00001;
             txtinvoiceno.Text = Strings.Format(ID, "000000")
            }
    
       protected void btnsavef1_Click(object sender, EventArgs e)
       {
         ID++;
         var no = Convert.ToInt32(ID);
          txtinvoiceno.Text = Strings.Format(no, "000000")
        }
    }
