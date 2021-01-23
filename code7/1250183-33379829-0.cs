    private void displayButton_Click(object sender, EventArgs e)
    {
        const int SIZE = 100;
        decimal[] sales = new decimal[SIZE];
        int count = 0;
        decimal totalSales, averageSales, minSales, maxSales;
        StreamReader inputFile;
        inputFile = File.OpenText("../../Sales.txt");
        try
        {
            while (!inputFile.EndOfStream && count < sales.Length)
            {
                sales[count] = decimal.Parse(inputFile.ReadLine());
                minSales = count == 0 ? sales[count] : Math.Min(minSales, sales[count]);
                maxSales = count == 0 ? sales[count] : Math.Max(maxSales, sales[count]);
                totalSales += sales[count];
                ListBox.Items.Add(sales[count]);
                count++;
            }
            inputFile.Close();
            averageSales = totalSales / sales.Length;  
            TotalSales.Text = totalSales;
            AverageSales.Text = averageSale;
            MinSales.Text = minSales;
            MaxSales.Text = maxSales;
        }              
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
