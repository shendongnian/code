    // I'm using collection initializers here! 
    var groups = new Dictionary<string, Dictionary<string, string>>
    {
         { 
              "Coverage", 
              new Dictionary<string, string> 
              {
                   { "sheet1", "COVC1" },
                   { "sheet2", "COVC2" }
                   // And so on...
              }
         },
         {
              "IncomeInvestment",
              new Dictionary<string, string>
              {
                   { "Income1", "IEIC1" }
                   // And so on...
              }
         }
    };
