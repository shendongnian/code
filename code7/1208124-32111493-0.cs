    if (first.Field<string>("SameReferences") != null)
    {
        string duplicate = first.Field<int>("SortOrder").ToString();
        string sameReference = first.Field<string>("SameReferences");
        if (String.IsNullOrEmpty(sameReference))
            first.SetField("SameReferences", duplicate);
        else
            first.SetField("SameReferences", string.Format("{0},{1}", duplicate, sameReference));
    }
