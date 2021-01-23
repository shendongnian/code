    private void Purchase_AddNewRecord()
	{
		fmAddEditPurchase addForm = new fmAddEditPurchase();
		if (addForm.ShowDialog() == 
			DialogResult.OK && addForm.Purchase.Total_Amount > 0)
		{
			using (var context = new dbKrunchworkContext())
			{
				context.Purchases.Add(addForm.Purchase);
				foreach (var purchasedProduct in addForm.Purchase.PurchasedProducts)
				{
					context.Entry(purchasedProduct.Product).State = EntityState.Unchanged;
				}
				context.SaveChanges();
			} 
		}
	}
