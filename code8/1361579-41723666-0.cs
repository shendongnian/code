    FooViewModel foo;
    BarViewModel bar;
    public void Foo_UpdateItem([Control("BarCount")] int? barCount)
    {
      TryUpdateItem(foo);
      var bars = (ListView)Entry.FindControl("FooBars");
      for (var i = 0; i < barCount; ++i)
      {
          bar = foo.Bars[i];
          bars.UpdateItem(i, false);
      }
    }
