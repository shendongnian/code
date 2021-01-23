    MyBase[] array = new MyBase[] { new Derived1() , new Derived2(), new Derived1()}
    int [] input = new int[] { 1,2,3,4,5,6,7,8,9};
    IEnumerable<int> unusedInputs = input;
    foreach (MyBase entity in array)
    {
         unusedInputs = entity.ReadData(unusedInputs);
    }
