      List<decimal> total = new List<decimal>();
      
      private void btnCalculate_Click(object sender, EventArgs e)
      {
          // You don't have a limit of 5 totals with a List but you
          // could continue to add new totals unless you reach the
          // end of available memory (very improbable with this)
          ....
          total.Add(invoiceTotal);
          ...
      }
