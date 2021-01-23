    string str = "=?utf-8?B?2KfbjNmGINuM2qkg2YXYqtmGINiz2KfYr9mHINin2LPYqg==?= =?utf-8?B?2KfbjNmGINuM2qkg2YXYqtmGINiz2KfYr9mHINin2LPYqg==?= =?utf-8?B?2YbYr9is?=";
    const string utf8b = "=?utf-8?B?";
    var parts = str.Split(new[] { "?=" }, 0);
    foreach (var part in parts)
    {
        string str2 = part.Trim();
        if (str2.StartsWith(utf8b, StringComparison.OrdinalIgnoreCase))
        {
            str2 = str2.Substring(utf8b.Length);
            byte[] bytes = Convert.FromBase64String(str2);
            string final = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(final);
        }
        else if (str2 == string.Empty)
        {
            // Nothing to do here
        }
        else
        {
            Console.WriteLine("Not recognized {0}", str2);
        }
    }
