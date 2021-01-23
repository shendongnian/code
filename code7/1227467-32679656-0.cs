    protected void Button3_Click(object sender, EventArgs e)
    {
        // cancel the selected transaction
        string selectedBarcode = dgvData.Rows[0].Cells[12].Text;
        using(var dataContext = new HasinReservation.Entities.Db())
        {
            var transaction = dataContext.Transaction.Single(t => t.Barcode == selectedBarcode);
            transaction.IsCancelled = true;
            dataContext.SaveChanges();
        }
    }
