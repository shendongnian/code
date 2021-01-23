    public int AllSameSign(IEnumerable<int> theInputList, bool positive = true)
    {
         if (positive)
             return theInputList.All(i=>i >= 0);
         else
             return theInputList.All(i=>i < 0);
    }
