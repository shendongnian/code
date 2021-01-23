    using System;
    using System.Web;
    var incomingStrings = new[] { "not encoded", "encod&eacute;d" };
    foreach (var incomingString in incomingStrings)
    {
        Console.WriteLine(IsUrlEncoded(incomingString));
    }
    private bool IsUrlEncoded(string source)
    {
        return source != HttpUtility.UrlDecode(source);
    }
