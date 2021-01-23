    public static List<ListMember> ReOrder(this List<ListMember> list)
    {
        int Index = 0;
    
        foreach (ListMember member in list.OrderBy(x => x.DateEntered))
        {
            if (member.DateExited == null)
            {
                member.ListOrder = Index;
    
                Index++;
            }
            else
            {
                member.ListOrder = -1;
            }
        }
    
        return list;
    }
