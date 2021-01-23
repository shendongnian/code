    public static void SwapAfterIndex(List<string> listA, List<string> listB, int index)
    {
        List<string> temp = listA.GetRange(index, listA.Count - index);
        listA.RemoveRange(index, listA.Count - index);
        listA.AddRange(listB.GetRange(index, listB.Count - index));
            
        listB.RemoveRange(index, listB.Count - index);
        listB.AddRange(temp);
    }
