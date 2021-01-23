    public void MethodC(ClassB classB, int userId)
    {
        int index = 0;
        classB.ClassA = new ClassA[(ClassA[])Enum.GetValues(typeof(ClassA)).Length];
        foreach(ClassA classA in (ClassA[])Enum.GetValues(typeof(ClassA)))
        {
            classB. ClassA [index++] = classA;
        }
    }
