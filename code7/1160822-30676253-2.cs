    public static string FormatHebrew(this int num)
    {
      if(num <= 0)
        throw new ArgumentOutOfRangeException();
      StringBuilder ret = new StringBuilder(new string ('ת', num / 400));
      num %= 400;
      if(num >= 100)
      {
        ret.Append("קרש"[num / 100 - 1]);
        num %= 100;
      }
      switch(num)
      {
        // Avoid letter combinations from the Tetragrammaton
        case 16:
          ret.Append("טז");
          break;
        case 15:
          ret.Append("טו");
          break;
        default:
          if (num >= 10)
          {
            ret.Append("כלמנסעפצי"[num / 10 - 1]);
            num %= 10;
          }
          if(num > 0)
            ret.Append ("אבגדהוזחט" [num - 1]);
            break;
      }
      return ret.ToString ();
    }
