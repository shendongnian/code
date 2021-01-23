    public void test()
    {
      //Initiate the collection before using it.
      ACInvoiceRows = new List<IWebElement>();
      foreach(IWebElement row in InvoiceRows)
      {
          if(row.Text.Contains("AC"))
          {
              ACInvoiceRows.Add(row);
          }
      }
      Console.WriteLine(ACInvoiceRows.Count);
    }
