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
        IEnumerable<double> relevant = b.Where(item => item > 0);
        soma = relevant.Sum();
        result = soma / relevant.Count();
        lblmedia.Text = result.ToString();
    }
