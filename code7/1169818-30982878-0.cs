    public async Task<HttpResponseMessage> GetPdf()
    {
        //normally us a using statement for streams, but if you use one here, the stream will be closed before your client downloads it.
        Stream stream;
        try
        {
            //container setup earlier in code
            var blockBlob = container.GetBlockBlobReference(fileName);
            stream = await blockBlob.OpenReadAsync();
            //Set your response as the stream content from Azure Storage
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentLength = stream.Length;
            //This could change based on your file type
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        }
        catch (HttpException ex)
        {
            //A network error between your server and Azure storage
            return this.Request.CreateErrorResponse((HttpStatusCode)ex.GetHttpCode(), ex.Message);
        }
        catch (StorageException ex)
        {
            //An Azure storage exception
            return this.Request.CreateErrorResponse((HttpStatusCode)ex.RequestInformation.HttpStatusCode, "Error getting the requested file.");
        }
        catch (Exception ex)
        {
            //catch all exception...log this, but don't bleed the exception to the client
            return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }
        finally
        {
            stream = null;
        }
    }
