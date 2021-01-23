    [Test]
    public void DoStuff() {
      List<object> things = new List<object>() {
        new ResultA(){Date = DateTime.Now, Month = 34}, new ResultB(){Count = 1, Jewels = 4, Number = "2", Update = "0"}
      };
      foreach (var thing in things) {
        foreach (var property in thing.GetType().GetProperties()) {
          Trace.WriteLine(property.Name + " " + property.GetValue(thing));
        }
      }
    }
