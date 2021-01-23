    Uri uri = new Uri("http://localhost/subApp/subApp2/index.aspx");
    StringBuilder alias = new StringBuilder();
    for (int i = 1; i < (uri.Segments.Count() -1); i++)
    {
        alias.Append(uri.Segments[i]);
    }
