    // Read all your lines:
    string source = System.IO.File.ReadAllText(path_to_your_file);
    // Split them on new lines, ignore any empty lines
    var lines = source.Split(Environment.NewLine.ToCharArray()
                            , StringSplitOptions.RemoveEmptyEntries );
    // Iterate over your `lines` here
    // ...
	
