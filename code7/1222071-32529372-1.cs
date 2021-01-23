    string vehicle = "car-blue-diesel-ford-com-";
    string chars = "(,@.)";
    MatchCollection matches = Regex.Matches(vehicle, "-");
    var sb = new StringBuilder(vehicle);
    if (matches.Count != chars.Length) {
        throw new ArgumentException("Supply the right number of replacement chars");
    }
    for (int i = 0; i < matches.Count; i++) {
        sb[matches[i].Index] = chars[i];
    }
    string output = sb.ToString(); // "car(blue,diesel@ford.com)"
