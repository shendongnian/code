    class ButtonConfig
    {
      public string Name { get; set; }
      public string Text { get; set; }
    }
    
    var myButtons = new [
      new ButtonConfig { Name = "OKBtn", Text = "OK" },
      new ButtonConfig { Name = "CancelBtn", Text = "Cancel" },
      // ...
    ]
