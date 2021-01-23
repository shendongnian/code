    private void Purchase_AddNewRecord()
    {
        fmAddEditPurchase addForm = new fmAddEditPurchase();
        if (addForm.ShowDialog() == 
            DialogResult.OK && addForm.Purchase.Total_Amount > 0)
        {
            using (var context = new dbKrunchworkContext())
            {
                context.Purchases.Add(addForm.Purchase);
                context.SaveChanges();
            } 
        }
    }
