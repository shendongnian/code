    class Person
    {
      public string FullName
      {
        get;
        set;
      }
      
      public string Address
      {
        get;
        set;
      }
    }
    
    void SetupView()
    {
      var template = new DataTemplate (typeof (TextCell));
      
      // We can set data bindings to our supplied objects.
      template.SetBinding (TextCell.TextProperty, "FullName");
      template.SetBinding (TextCell.DetailProperty, "Address");
      
      // We can also set values that will apply to each item.
      template.SetValue (TextCell.TextColorProperty, Color.Red);
      
      itemsView.ItemTemplate = template;
      itemsView.ItemsSource = new[] {
        new Person { FullName = "James Smith", Address = "404 Nowhere Street" },
        new Person { FullName = "John Doe", Address = "404 Nowhere Ave" }
      };
    }
