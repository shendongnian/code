    string str = "abc def ghi         xyz";
    var result = str.Split(); //This will remove single spaces from the result
    StringBuilder sb = new StringBuilder();
    bool ifMultipleSpacesFound = false;
    for (int i = 0; i < result.Length;i++)
    {
        if (!String.IsNullOrWhiteSpace(result[i]))
        {
            sb.Append(result[i]);
            ifMultipleSpacesFound = false;
        }
        else
        {
            if (!ifMultipleSpacesFound)
            {
                ifMultipleSpacesFound = true;
                sb.Append(" ");
            }
        }
    }
    string output = sb.ToString();
