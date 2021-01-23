     foreach (var item in DataContext.GetChangeSet().Inserts)
	 {
	    IDataErrorInfo errofInfo = item as IDataErrorInfo;
         if(errofInfo != null && !string.IsNullOrEmpty(errofInfo.Error))
         {
             //// Error Exist;
         }
	 }
     foreach (var item in DataContext.GetChangeSet().Updates)
	 {
	    IDataErrorInfo errofInfo = item as IDataErrorInfo;
         if(errofInfo != null && !string.IsNullOrEmpty(errofInfo.Error))
         {
             //// Error Exist;
         }
	 }
				
