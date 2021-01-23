    public static Boolean Checker(String check, bool isDate)
    {
       if(isDate)
       {
           DateTime dt;
           // Here you could add your formatting locale as you find appropriate
           return DateTime.TryParse(check, out dt); 
       }
       else
           return check.Length > 0 && check.Length <= 30;
    }
