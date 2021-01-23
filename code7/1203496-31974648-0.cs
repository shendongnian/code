    private static MyUnit inch;
    public static MyUnit Inch
    {
        get
        {
            if (inch == null)
                inch = new MyUnit("inch", "inch", "in", UnitPurpose.DISTANCE, 2);
             return inch;
        }
    }
