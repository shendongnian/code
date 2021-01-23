    foreach (XElement parameter in paramsList) {
        if (parameter.Attribute("name").Value == "Weight") {
        int value;
        if(!Int32.TryParse(parameter.Attribute("value").Value, out value)){
             //Not a number, handle this case
        }
        if ((value > 55) &&  (value < 100)){
            return true;
        }
        return result;
    }
