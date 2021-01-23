    var myStr = "= '2015-12-01 00:00:00.000'";
    var match = Regex.Matches(myStr, "\'([^\']*)\'")[0];
    DateTime result;
    if (DateTime.TryParse(match.ToString(), out result)) {
        // Your string has a valid DateTime and it is parsed in result
    }
    else {
       // Invalid
    }
    
