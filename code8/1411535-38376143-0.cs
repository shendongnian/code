    public enum ADalEnum : int
    {
      One = 1,
      Two = 2,
      Three = 3
    }
...
    public enum MappedEnum : int
    {
      One_Little_Indians = ADalEnum.One,
      Two_Little_Indians = ADalEnum.Two,
      Three_Little_Indians = ADalEnum.Three,
    }
