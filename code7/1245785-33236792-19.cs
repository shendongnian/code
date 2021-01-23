    var settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Error = (sender, args) =>
            {
                args.ErrorContext.Handled = true;
            },
        };
    using(var context = new myContext())
    {
        var myEntity = myContext.Foos.First();
        return JsonConvert.SerializeObject(myEntity, settings);
    }
