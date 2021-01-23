    struct MyStruct
    {
        public int a, b, c;
        public int SumABC() { return a + b + c; }
    }
    int Test(int id)
    {
        return MyArray[id].SumABC();
    }
