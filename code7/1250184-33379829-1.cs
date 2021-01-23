    private void displayButton_Click(object sender, EventArgs e)
    {
        List<decimal> sales = new List<decimal>(); // notice: no size limitation
        StreamReader inputFile;
        inputFile = File.OpenText("../../Sales.txt");
        try
        {
            while (!inputFile.EndOfStream)
            {
                var sale = decimal.Parse(inputFile.ReadLine()); 
                sales.Add(sale);
                ListBox.Items.Add(sale);
            }
            inputFile.Close();
            TotalSales.Text = sales.Sum();
            AverageSales.Text = sales.Average();
            MinSales.Text = sales.Min();
            MaxSales.Text = sales.Max();
        }              
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
