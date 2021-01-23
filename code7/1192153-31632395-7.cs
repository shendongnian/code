    public static void SwapAfterIndex(List<string> listA, List<string> listB, int index)
    {
        if (index < 0)
        {
            return;
        }
        List<string> temp = null;
        if (index < listA.Count)
        {
            temp = listA.GetRange(index, listA.Count - index);
            listA.RemoveRange(index, listA.Count - index);
        }
        if (index < listB.Count)
        {
            listA.AddRange(listB.GetRange(index, listB.Count - index));
            listB.RemoveRange(index, listB.Count - index);
        }
        if (temp != null)
        {
            listB.AddRange(temp);
        }
    }
