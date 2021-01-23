    double tempValue;
    
    if (Double.TryParse(yourObject.Temperature, out temp)){
      // successfully parsed to a double
      // do whatever you're going to do with the value
    }
    else {
      // couldn't be parsed as a double, handle accordingly
    }
