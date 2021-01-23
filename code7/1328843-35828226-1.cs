    public static class PathExt
    {
        public static String ReplaceInvalidChars(String path, Char replacement = '_')
        {
            if (String.IsNullOrEmpty(path))
                throw new ArgumentException(paramName: nameof(path), message: "Empty or null path");
            var invalidChars = new HashSet<Char>(Path
                .GetInvalidFileNameChars()
                .Concat(Path.GetInvalidPathChars()));
            
            return new String(path
                .Select(ch =>
                    invalidChars.Contains(ch) ?
                        replacement : ch)
                .ToArray());
        }
    }
...
    var dateTime = DateTime.Now.ToString();
    var dateTimePath = PathExt.ReplaceInvalidChars(dateTime);
    Console.WriteLine($"The time is {dateTime}");
    Console.WriteLine($"The file is {dateTimePath}");
    using (File.Create(dateTimePath))
    {
        Console.WriteLine("File created");
    }
