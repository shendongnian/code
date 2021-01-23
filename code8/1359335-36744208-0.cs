    private double TotalColumn(int col) {
        double Total = 0;
        for (int i = 0; i < DGV_INVOICE.Rows.Count; ++i) {
            double num = 0;
            if (double.TryParse(DGV_INVOICE.Rows[i].Cells[col].Value.ToString(), out num)) {
                Total+=num;
            }
        }
        return Total;
    }
