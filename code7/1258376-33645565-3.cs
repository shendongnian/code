    public partial class Form1 : Form
    {
        double principal;
        double rate;
        double terms;
        double sum;
    
        public Form1()
        {
            InitializeComponent();
        }    
    
        private double add()
        {
            principal = Convert.ToDouble(inputTextBoxPrincipal.Text);
            rate = Convert.ToDouble(inputTextBoxRate.Text);
            terms = Convert.ToDouble(inputTextBoxTerms);
    
            sum = principal + rate + terms;
            return sum;
        }
    
        private void clickButtonEnter_Click(object sender, EventArgs e)
        {
            double sum = add();
                MessageBox.Show(sum.ToString());
        }
    
    }
