    public void Setpajamos(int newValue, List<string> errors)
    {
       if (newValue >= 0 && newValue <= 30)
       {
          pajamos = newValue;
       }
       else
       {
          errors.Add("Patikrinkite duomenis");
       }
    }
