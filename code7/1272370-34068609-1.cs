    var text = File.ReadAllText(inputfile);
    var rawParts = text.Split(new string[] { "\n" });
    var proParts = new List<string>(rawParts.Take(2));
    proParts.Add(rawParts[2] + " " rawParts[3] + " " rawParts[4]);
    proParts.AddRange(rawParts.Skip(5));
    var sb = new StringBuilder();
    foreach (var part in proParts)
      sb.Append(part + "\n");
    File.WriteAllText(outputfile, sb.ToString());
