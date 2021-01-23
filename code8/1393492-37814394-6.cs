     private void Save(SalesItem item)
        {
            if(!transportationDb._Payroll_Orders.Any(p => p.Ord_Inv_No == item.InvoiceNumber))
            {
                transportationDb._Payroll_Orders.Add(item.PayrollOrder);
                transportationDb.SaveChanges();
            }
            else
            {
                // Already exists
            }
        }
