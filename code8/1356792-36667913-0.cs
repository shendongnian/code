    protected void Page_Load(object sender, EventArgs e)
    {
        List<double> lstPrice = GetPrice();
        double dblPriceSum = lstPrice.Where(p => p > 0).Sum();
    
        lblCount.Text = string.Format("{0:#,##0  Rls}", dblPriceSum);
    }
    
    private List<double> GetPrice()
    {
        const int PriceColumnIndex = 0;
    
        List<double> resList = new List<double>();
    
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            string strPrice = GridView1.Rows[i].Cells[PriceColumnIndex].Text;
            double dblPrice;
            bool blIsParsable = double.TryParse(strPrice, out dblPrice);
    
            if (blIsParsable)
                resList.Add(dblPrice);
        }
    
        return resList;
    }
