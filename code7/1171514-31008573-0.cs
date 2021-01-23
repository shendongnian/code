        property = validationContext.ObjectType.GetProperty("VehicleYear");
        var value = property.GetValue(validationContext.ObjectInstance, null);
        int inputNumber;
        //First check if input is number
        if (!int.TryParse(value, out inputNumber))
        {
          this.ErrorMessage = "Input is not an integer!"
          //you could also throw an exception here (depends on your error handling)
          return new ValidationResult(this.ErrorMessage);
        }
        
       //retrieves the number of digits
        int countDigits = Math.Floor(Math.Log10(year) + 1);
        if (countDigits != 4)
        {
          this.ErrorMessage = String.Format("Input has {0} digits!",countDigits);
          return new ValidationResult(this.ErrorMessage);
        }
    
        if (inputNumber > (DateTime.Now.Year + 1))
        {
          this.ErrorMessage = "Year is in the future!";
          return new ValidationResult(this.ErrorMessage);
        }
        
        //inputNumber is now a valid year!
        if(inputNumber > 1980)
        {
           isVehicleOlderThan1981 = true;
        } else {
           isVehicleOlderThan1981 = false;
        }
