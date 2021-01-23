    public async void SendAttachmentByMailClick()
    {
    	// delete temp directory if it exists, then create brand new one each time
    	var tempFolder = Path.Combine(Path.GetTempPath(), "MyTempFolder");
    	if (Directory.Exists(tempFolder)) 
    	{ 
    		Directory.Delete(tempFolder, true); 
    	}
    	Directory.CreateDirectory(tempFolder);
    
    	// get your list asynchronously
    	List<string> paths = null; 
    	try  
    	{
            // I am doing this asynchronously but awaiting until I get files.  I
            // would use a TaskCompletionSource (google for it) and once you
            // receive each file, store it's path in a List<string> object.
            // Check that the List<string> Count is equal to passed in
            // selection.Count and when it is, pass the list to TrySetResult()
            // of TaskCompletionSource.  Wrap that in try...catch and in catch
            // block pass the exception to TrySetException method of 
            // TaskCompletionSource.  This method should await and return
            // Task object of TaskCompletionSource which will then contain the
            // list of paths to your downloaded files.  Then you move one with 
            // logic below to copy them to temp location and attach them from 
            // there.
    		paths = await GetAttachmentsPaths(MyAddIn.ActiveExplorer.Selection);
    	}
    	catch (Exception e) 
    	{
    		// handle exceptions 
    		return;
    	}
    
    	// create new message
    	Microsoft.Office.Interop.Outlook.MailItem oMailItem = MyAddIn.Application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem); 
    	
    	if (paths != null && paths.Count > 0)
    	{
    		var attachmentFileName = String.Empty; 
    		try
    		{
    			// if list has downloaded files, copy them to tempFolder
    			List<string> copiedPaths = GetCopiedPaths(tempFolder, paths);
    
    			if (copiedPaths.Count > 0)
    			{
    			    // then attach each from that location
    				foreach (var itemPath in copiedPaths)
    				{
    					FileInfo fInfo = new FileInfo(itemPath);
    					if (fInfo.Exists)
    					{
    						attachmentFileName = fInfo.Name; 
    						oMailItem.Attachments.Add(itemPath, OlAttachmentType.olByValue, 1, fInfo.Name);
    					}
    					// delete file once attached to clean up
    					fInfo.Delete();
    				}
    			}
    
    			if (oMailItem.Attachments.Count > 0)
    			{
    				oMailItem.Display(false);
    			}
    		}
    		catch (Exception ex)
    		{
    			// handle exceptions
    		}
    		finally
    		{
    			// delete temporary folder once done
    			if (Directory.Exists(tempFolder)) 
    			{ 
    				Directory.Delete(tempFolder, true); 
    			}
    		}
    	}  
    }
