      String path = null;
      var files = File
        .ReadLines(@"C:\MyFiles.txt")
        .Select(line => {
          if (Path.IsPathRooted(line)) {
            path = Path.GetDirectoryName(line);
            return line;
          }
          else
            return  Path.Combine(path, line.Trim());
        });
    ...
    Console.WriteLine(String.Join(Environment.NewLine, files));
