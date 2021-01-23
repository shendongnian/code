    Char currentCurrency = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol.ToCharArray()[0];
    
    // Get your Double number,
    Double result = null;
    
    try {
        Regex regexObj = new Regex(@"[^\d]");
        result = Convert.ToDouble(regexObj.Replace(input, ""));
    } catch (ArgumentException ex) {
        // Syntax error in the regular expression
    }
    
    Switch(currentCurrency){
      // Append or prepend your currency symbol to your input
    }
