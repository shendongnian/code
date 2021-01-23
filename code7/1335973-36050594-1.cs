    public partial class Form1 : Form
    {
        private void calculate_Click(object sender, EventArgs e)
        {
            // declare local variables...
            // overwrite global varables.
            double total = 0; //total amount
            double tip = 0; //tip percentage
            double meal = 0; //meal amount
    
            // maybe, you want to invoke textbox.Text.
            // but, tip(TextBox) object is overwrote by double.
            // double has not the Text property, throw exception.
            tip = Convert.ToDouble(tip.Text) / 100; 
            meal = Convert.ToDouble(meal.Text);
            total = (meal * tip);
            total.Text = "$ " + Convert.ToString(total);
        }
    }
