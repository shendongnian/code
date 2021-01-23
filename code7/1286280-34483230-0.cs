     Shell shell = new Shell();
     var folder = shell.NameSpace( <path_to_your_zip> );
     // Just get the names of the properties
     List<string> arrHeaders = new List<string>();
     for (int i = 0; i < short.MaxValue; i++)
     {
       string header = folder.GetDetailsOf(null, i);
       if (String.IsNullOrEmpty(header))
         break;
       arrHeaders.Add(header);
     }
     // Loop all files inside the zip and output their properties to console
     foreach (Shell32.FolderItem2 item in folder.Items())
     {
       for (int i = 0; i < arrHeaders.Count; i++)
       {
         Console.WriteLine("{0}\t{1}: {2}", i, arrHeaders[i], folder.GetDetailsOf(item, i));
       }
     }
