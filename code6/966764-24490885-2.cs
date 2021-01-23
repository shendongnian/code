     int[] a = new int[] { 1, 2, 3, 4 };
     int[] b = new int[] { 1, 2, 3 };
     var result = a.Except(b).ToArray();
     foreach (var item in result)
     {
        Response.Write("\nItems not in B are :"+item);
     }
    
