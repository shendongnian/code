    public void myComplexMethod(List<MyTypeA> paramObjectsA)
    {
        foreach(MyTypeA iteratorA in paramObjectsA)
        {
            MyTypeB myObjectB = MyTypeB.Create(iteratorA);
        }
    }
