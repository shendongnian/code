    protected void TextDate_TextChanged(object sender, EventArgs e)
    {
        ...
        CADCATOPS.DSCATOPS.BatchDatos1DataTable AllFila = CADCATOPS.CADBatchHandoff.AllTraeFilaHO(Convert.ToString(FechaCT1));
        foreach (GridViewRow row in GridView1.Rows)
        {
            ....
            if (row.RowType == DataControlRowType.DataRow)
            {
                string IDBatch = row.Cells[0].Text;
                DataRow foundRow = AllFila.Rows.Find(IDBatch);
                ...
            }
        }
    }
