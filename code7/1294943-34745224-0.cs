        var client = new Windows.Web.Http.HttpClient(); // prepare the http client 
    
    //get the response from the server
    using (var webResponse = await client.GetAsync(downloadOperation.Link, HttpCompletionOption.ResponseHeadersRead)) //***********Node the HttpCompletionOption.ResponseHeaderRead, this means that the operation completes as soon as the client receives the http headers instead of waiting for the entire response content to be read
    {
    	using (var downloadStream = (await webResponse.Content.ReadAsInputStreamAsync()).AsStreamForRead() )
    	{
    		using (var outputFileWriteStream = await outputFile.OpenStreamForWriteAsync())
    		{
    			var buffer = new byte[4096];
    			var downloadedBytes = 0;
    			var totalBytes = webResponse.ContentLength;
    			while (downloadedBytes < totalBytes)
    				{
    					//*************************THIS LINE NO LONGER TAKES A LONG TIME TO PERFORM FIRST READ***************************
    					var currentRead = await downloadStream.ReadAsync(buffer, 0, buffer.Length);
    					//*******************************************************************************************************************************************************************
    
    					await outputFileWriteStream.WriteAsync(buffer, 0, currentRead); 
    				}
    		}
    
    	}
    
    }
