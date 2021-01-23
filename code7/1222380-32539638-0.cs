    public void doSomething ( IEnumerable<int> myPassedValues ) 
    {
        List<int> newList = myPassedValues.ToList();
        int A = 5;
        newList.Add(A);
        //... And then some other cool code with this modified list
    }
