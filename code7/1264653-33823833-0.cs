    private string ValidateValue<T>(T EnqTagList, ValidationDelegate del) 
    {
        if (EnqTagList.GetType().GetGenericArguments()[0] == typeof(List<HeaderTypeEnq<dynamic>>))
        {
         //code
        }
    }
