    private void DoStuffCast(dynamic obj)
    {
       obj.Content = "Foo"; // ie, generically handle it.
       Console.WriteLine(obj.GetType().Name + "!!");
    }
