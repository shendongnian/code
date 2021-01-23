    public static string testMethod()
    {
      try
      {
        int num1 = 100;
        int num2 = 0;
        int num3 = num1 / num2;
        return Convert.ToString(num1 - num3);
      }
      catch (Exception ex)
      {
        return Convert.ToString((object) ex);
      }
    }
