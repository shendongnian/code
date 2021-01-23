    using System;
    using System.Web;
    var incomingStrings = new[] { "not encoded", "encod&eacute;d" };
    foreach (var incomingString in incomingStrings)
    {
        Console.WriteLine(IsHtmlEncoded(incomingString));
    }
    private bool IsHtmlEncoded(string source)
    {
        return source != HttpUtility.HtmlDecode(source);
    }
