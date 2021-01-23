    string value_00 = driver.FindElementByXPath("//div[@id='targetSummaryCount']/span[1]").Text;
    string value_20 = driver.FindElementByXPath("//div[@id='targetSummaryCount']/span[3]").Text;
    
    // or
    var elements = driver.FindElementsByXPath("//div[@id='targetSummaryCount']/span");
    string value_00 = elements[0].Text;
    string value_01 = elements[2].Text;
