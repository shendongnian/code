    var newlineRegx = new Regex("(\\r\\n|\\n|\\r)",RegexOptions.Multiline);
    Handlebars.RegisterHelper("handleNewLines", (output, context, arguments) =>
    {
        var str = newlineRegx.Replace((string)arguments[0], "<br>");
        output.Write(str);
    });
