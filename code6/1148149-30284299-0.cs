    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected void addButton_Click(object sender, EventArgs e)
        {
            double firstValue = double.Parse(firstTextBox.Text);
            double secondValue = double.Parse(secondTextBox.Text);
            double addValue = firstValue + secondValue;
            resultLabel.Text = addValue.ToString();
        }
    
        protected void subtractButton_Click(object sender, EventArgs e)
        {
            double firstValue = double.Parse(firstTextBox.Text);
            double secondValue = double.Parse(secondTextBox.Text);
            double addValue = firstValue - secondValue;
            resultLabel.Text = addValue.ToString();
        }
    
        protected void multiplicationButton_Click(object sender, EventArgs e)
        {
            double firstValue = double.Parse(firstTextBox.Text);
            double secondValue = double.Parse(secondTextBox.Text);
            double addValue = firstValue * secondValue;
            resultLabel.Text = addValue.ToString();
        }
    
        protected void divideButton_Click(object sender, EventArgs e)
        {
            double firstValue = double.Parse(firstTextBox.Text);
            double secondValue = double.Parse(secondTextBox.Text);
            double addValue = firstValue / secondValue;
            resultLabel.Text = addValue.ToString();
        }
    }
