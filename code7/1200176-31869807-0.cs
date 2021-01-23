    string[] arr1 = new string[] { arctopithecusGalleryPath, arctopithecusGalleryPath1, arctopithecusGalleryPath3 };
    
    for (int i = 0; i < arr1.Length; i++)
    {
    	   if (System.IO.Directory.Exists(array[i]) == false){
           System.IO.Directory.CreateDirectory(array[i]);              
    }
