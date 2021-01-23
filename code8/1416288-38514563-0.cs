    var assembly = Assembly.GetExecutingAssembly();
    using(var stream = assembly.GetManifestResourceStream("TestFile.xml"))
    using(TextReader tr = new StreamReader(stream))
    {
          Console.WriteLine(tr.ReadToEnd());
    }
