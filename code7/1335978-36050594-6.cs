    private void calculate_Click(object sender, EventArgs e)
    {
        double total = 0; //total amount
        double tip = 0; //tip percentage
        double meal = 0; //meal amount
        tip = Convert.ToDouble(this.tip.Text) / 100;
        meal = Convert.ToDouble(this.meal.Text);
        total = (meal * tip);
        this.total.Text = "$ " + Convert.ToString(total);
    }
