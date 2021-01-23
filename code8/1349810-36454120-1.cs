    public static Main()
    {
       if(Enum.GetNames(typeof(Item.Type)).Length != Item.TypeCount)
          throw new ApplicationException ("TypeCount and number of Types do not match.\nPlease update TypeCount constant.")
    }
