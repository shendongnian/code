    IEnumerator<int> MyEnumerationMethod()
    {
        yield return 5;
        yield return 1;
        yield return 9;
        yield return 4;
    }
    void UserMethod1()
    {
        foreach (int retVal in MyEnumerationMethod())
            Console.Write(retVal + ", ");
        // this does print out 5, 1, 9, 4, 
    }
    void UserMethod2()
    {
        IEnumerator<int> myEnumerator = MyEnumerationMethod();
        while (myEnumerator.MoveNext())
            Console.Write(myEnumerator.Current + ", ");
        // this does print out 5, 1, 9, 4, 
    }
