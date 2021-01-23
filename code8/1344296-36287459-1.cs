    string value_00 = driver.FindElementByCssSelector("#targetSummaryCount > span:nth-child(1)").Text;
    string value_20 = driver.FindElementByCssSelector("#targetSummaryCount > span:nth-child(3)").Text;
    
    // or
    var elements = driver.FindElementsByCssSelector("#targetSummaryCount > span:nth-child(odd)");
    string value_00 = elements[0].Text;
    string value_01 = elements[1].Text;
