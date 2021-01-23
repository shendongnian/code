        //Declare this in the class so that it can be called by any method
    static Object[] array = new Object[4];
    public static void main()
    {
        //Use this to initialize it
        Object[] array = new Object[4];
        for(int i=0;i<4;i++)
        {
            array[i] = new Object();
        }
        //You can now easily call it
        useObject(0);
        useObject(1);
        useObject(2);
        useObject(3);
    }
    //Your numbers may be off by 1 because we are using an array but that is easily adjusted
    public static void useObject(int objectNumber)
    {
        array[objectNumber].doAnythingWithThisObject();
    }
