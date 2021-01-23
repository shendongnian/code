    // Create an array of the parameters, including the separator 
    var parameters = new string[5];
    parameters[0] = string.Empty;
    parameters[1] = "area";
    parameters[2] = "origin";
    parameters[3] = "destination";
    parameters[4] = "type";
    // Will give: areaorigindestinationtype
    var result1 = String.Format("{1}{0}{2}{0}{3}{0}{4}", parameters);
    
    // Now change the separator:
    parameters[0] = "-";
    // Will give: area-origin-destination-type
    var result2 = String.Format("{1}{0}{2}{0}{3}{0}{4}", parameters);
    // Finally, reverse the last four parts:
    Array.Reverse(parameters, 1, 4);
    // Will give: type-destination-origin-area
    var result3 = String.Format("{1}{0}{2}{0}{3}{0}{4}", parameters); 
