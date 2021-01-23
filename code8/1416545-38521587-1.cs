    public static MeridDataType InitMeridDataType()
    {
       return new MeridDataType()  // the parentheses are actually optional
       {
           NumCurves = 0,
           CurveData = null
       };
    }
