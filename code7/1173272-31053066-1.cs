    private async void button1_Click(object sender, EventArgs e)
    {
        try
        {
            double result = await Task.Run(() => this.SlowDivision(3, 0));
            this.Label1.Text = result.ToString();
        }
        catch (Exception ex)
        {
            this.textBox1.Text = ex.ToString();
        }
    }
    private double SlowDivision(double a, double b)
    {
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
        if (b == 0) throw new ArgumentException("b");
        return a / b;
    }
