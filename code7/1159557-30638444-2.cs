    int quantityColumnIndex = 3;  // use your own numbers..
    int currencyColumnIndex = 1;  // ..and names!!
    int currencyRowIndex = 0;
    int pricePerUnitColumnIndex = 7;
    int totalPriceColumnIndex = 8;
    int totalBasePriceColumnIndex = 4;
    private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == quantityColumnIndex) doPriceCalc(e);
        else if (e.ColumnIndex == currencyColumnIndex && e.RowIndex == currencyRowIndex) 
             doAllCalc(e);
    }
    void doPriceCalc(DataGridViewCellEventArgs e)
    {
        // 1st example
        DGV[totalPriceColumnIndex, e.RowIndex].Value =
            (int)DGV[quantityColumnIndex, e.RowIndex].Value *
            (decimal)DGV[pricePerUnitColumnIndex, e.RowIndex].Value;
    }
    void doAllCalc(DataGridViewCellEventArgs e)
    {
        // 2nd example
        decimal currency = (decimal) DGV[currencyColumnIndex,currencyRowIndex ].Value;
        for (int row = 0; row < DGV.Rows.Count; row++)
            DGV[pricePerUnitColumnIndex, e.RowIndex].Value =
                (decimal)DGV[totalBasePriceColumnIndex, e.RowIndex].Value * currency;
    }
