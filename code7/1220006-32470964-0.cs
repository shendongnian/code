    using System.IO;
    using System.Text.RegularExpressions;
    var pattern = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
    var r = new Regex(string.Format("[{0}]", Regex.Escape(pattern)));
    tempFileName = r.Replace(tempFileName, "_");
