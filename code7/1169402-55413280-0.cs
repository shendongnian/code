    Handlebars.RegisterHelper("ifCond", (writer, options, context, arguments) =>
    {
        if (arguments[0] == arguments[1])
        {
            options.Template(writer, (object)context);
        }
        else
        {
            options.Inverse(writer, (object)context);
        }
    });
