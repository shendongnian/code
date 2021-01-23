    var errors = new List<string>();
    
    List<DateTime> c = JsonConvert.DeserializeObject<List<DateTime>>(
        yourJsonHere,
        new JsonSerializerSettings
        {
            Error = delegate(object sender, ErrorEventArgs args)
            {
                errors.Add(args.ErrorContext.Error.Message);
                args.ErrorContext.Handled = true;
            }
        });
