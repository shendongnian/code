    String country = "United States - US Dollars ($)";
    Select select=new Select(wd.FindElement(By.Id("CountrySelector"))
    select.selectByVisibleText(country);  //Here selects the country
    //Now to cross check, get the value which is selected by below statement.
    String returnSelectedCountry=select.getFirstSelectedOption(); //This will actually fetch the value from the listbox
    if(!country.equals(returnSelectedCountry)) //Comparing the string var with actual val selected
      PayPal();
    else
      WePay();
 
