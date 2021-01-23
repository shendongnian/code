    var settings = new JsonSerializerSettings
    {
        Error = (sender, args) => 
        {
            if (object.Equals(args.ErrorContext.Member, "test") && 
                args.ErrorContext.OriginalObject.GetType() == typeof(NewtonTest))
            {
                args.ErrorContext.Handled = true;
            }
        }
    };
    
    NewtonTest test = JsonConvert.DeserializeObject<NewtonTest>(json, settings);
