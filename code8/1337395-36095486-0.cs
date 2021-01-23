    var s = "Alex Amonov,Semen Polov,John S,Alex Solid";
            
    var result = "";
    foreach (var name in Regex.Split(s, ",").Where(x => !string.IsNullOrEmpty(x)))
    {
        var index = name.IndexOf(" ", StringComparison.InvariantCulture);
        result += name[0] == name[index + 1] 
            ? name.Substring(0, index) + " " + name[0] + ", " 
            : name.Substring(0, index) + ", ";
    }
