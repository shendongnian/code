       var myObject = JsonConvert.DeserializeObject<ClassA>(str
       , new JsonSerializerSettings
       {
         Error = delegate(object sender, ErrorEventArgs args)
            {
                Console.WriteLine(args.ErrorContext.Error.Message);
                args.ErrorContext.Handled = true;
            },
         MissingMemberHandling = true
        });
