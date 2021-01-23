    IDictionaryEnumerator id = rs.GetEnumerator();
    List<Bitmap> CIcons = new List<Bitmap>();
    while (id.MoveNext())
    {
        if (id.Value is Bitmap)
            CIcons.Add((Bitmap)id.Value);
    }
