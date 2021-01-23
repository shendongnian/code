    List<string> arrHeaders = new List<string>();
    
    Shell32.Shell shell = new Shell32.Shell();
    var strFileName = @"C:\Users\Admin\Google Drive\image.jpg";
    Shell32.Folder objFolder = shell.NameSpace(System.IO.Path.GetDirectoryName(strFileName));
    Shell32.FolderItem folderItem = objFolder.ParseName(System.IO.Path.GetFileName(strFileName));
    
    for (int i = 0; i < short.MaxValue; i++)
    {
    	string header = objFolder.GetDetailsOf(null, i);
    	if (String.IsNullOrEmpty(header))
    		break;
    	arrHeaders.Add(header);
    }
    
    for (int i = 0; i < arrHeaders.Count; i++)
    {
    	var attrName = arrHeaders[i];
    	Debug.WriteLine("{0}\t{1}: {2}", i, attrName, objFolder.GetDetailsOf(folderItem, i));
    }
