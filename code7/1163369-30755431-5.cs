      [Test]
      public void DoItWithExtensionMethod() {
        List<object> things = new List<object>() {
        new ResultA(){Date = DateTime.Now, Month = 34}, new ResultB(){Count = 1, Jewels = 4, Number = "2", Update = "0"}
        };
      
        foreach (var thing in things) {
          var properties = thing.GetProperties();
          foreach (var property in properties) {
            Trace.WriteLine(property.Key + " " + property.Value);
          }
        }
      }
