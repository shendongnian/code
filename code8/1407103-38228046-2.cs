       List<string> colour = new List<String>{ "Red", "Orange", "Blue" };
       List<string> enumColors = Enum.GetNames(typeof(MyColours)).ToList();
       foreach (string s in enumColors)
       {
              if (colour.Exists(e => e == s))
                  return true;
              else
                  return false;
    
       }
