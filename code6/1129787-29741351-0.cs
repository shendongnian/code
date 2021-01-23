    private string GetPathToImage(Uri uri)
     {
       string path = null;
       // The projection contains the columns we want to return in our query.
       string[] projection = new[]       {Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data };
         using (ICursor cursor = ManagedQuery(uri, projection, null, null,  null))
         {
           if (cursor != null)
           {
             int columnIndex =   cursor.GetColumnIndexOrThrow(Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data);
            cursor.MoveToFirst();
            path = cursor.GetString(columnIndex);
           }
         }
   
    return path;
