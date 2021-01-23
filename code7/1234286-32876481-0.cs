     private string getMySubString(long value, int splitPart)
      {
         string str = value.ToString();
         if (str.Length != 11) return "invalid number lenght";
         string sub1 = str.Substring(0, 5);
         string sub2 = str.Substring(5, 4);
         string sub3 = str.Substring(9, 1);
         string sub4 = str.Substring(10, 1);
         switch (splitPart)
         {
            case 1:
               return sub1;
            case 2:
               return sub2;
            case 3:
               return sub3;
            case 4:
               return sub4;
            default:
               return "Invalid part number";
         }
      }
