    int[] groupIDs;
    FieldInfo listGroupIDMember;
    listGroupIDMember = typeof(ListViewGroup).GetField("id", BindingFlags.Instance | BindingFlags.NonPublic);
    groupIDs = new int[MyListView.Groups.Count];
    for (int i = 0; i < MyListView.Groups.Count; i++)
    {
        object result = listGroupIDMember.GetValue(MyListView.Groups[i]);
        if (result != null && result is int)
            groupIDs[i] = (int)result;
    }
