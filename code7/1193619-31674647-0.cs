    void Main()
    {
      var currencies = new List<Currency>() {
       new Currency { Code="EUR", Name="Euro"},
       new Currency { Code="USD", Name="US Dollars"},
       new Currency { Code="AUD", Name="Australian Dollars"},
       new Currency { Code="JPY", Name="Japanese Yen"},
      };
       
      var customer = new Customer { Id=1, Currency="", Notes=new List<string>()};
      
      Form f = new Form {Text="Sample"};
      ComboBox ddlCustomerCurrency = new ComboBox { Top=10, Left=10, Tag="", 
          DataSource=currencies, DisplayMember="Name"};
      Button b = new Button {Text = "Show Customer Notes", Top=60, Left = 10};    
          
      f.Controls.Add(ddlCustomerCurrency);
      f.Controls.Add(b);
      
      ddlCustomerCurrency.SelectedIndexChanged += (sender, args) => {
        var cmb = sender as ComboBox;
        if (cmb != null)
        {
          var currency = cmb.SelectedItem as Currency;
          var oldValue= cmb.Tag;
          if ( currency != null && oldValue != currency.Name )
          {
            customer.Notes.Add( string.Format(
              "\nOld Currency:{0}, New Currency:{1}, Ticks:{2}",
               oldValue, currency.Name, DateTime.Now.Ticks) );
            cmb.Tag = currency.Name;
          }
        }
      };
      
      b.Click += (sender,args) => {
        if (customer.Notes.Any ())
          MessageBox.Show( customer.Notes.Last () );
      };
      
      f.Show();
    }
    
    class Currency
    {
      public string Code { get; set; }
      public string Name { get; set; }
    }
    
    class Customer
    {
      public int Id { get; set; }
      public string Currency { get; set; }
      public List<string> Notes { get; set; }
    }
