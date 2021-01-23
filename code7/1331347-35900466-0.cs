    public double Evaluate(string expr)
    {
        System.Data.DataTable table = new System.Data.DataTable();
        return Convert.ToDouble(table.Compute(expr, String.Empty));
    }
