    public Media()
    {
        InitializeComponent();
    }
    
    List<double> b = new List<double>();
    double soma = 0;
    double result = 0;
    private void cmdcalc_Click(object sender, EventArgs e)
    {
           // txtb is an array too in this instance
        b.AddRange(txtb.Select(item => Convert.ToDouble(item.Text)));
        soma = b.Sum(item => item > 0 ? item : 0);
        result = soma / b.Count();
        lblmedia.Text = result.ToString();
    }
