    public void ActionMethod()
    {
        // declare image...
        Image image = null;
    
        try
        {
            // attempt to load image from stream...
            image = Image.FromStream(httpPostedFileBase.InputStream)
        }
        catch
        {
            // failed to load image from stream...
            ModelState.AddModelError( "", "File is not a valid image" );
            // exit
            return;
        }
        
        try
        {
            // perform additional processing...
            MoreStuffToDo(image);
        }
        catch
        {
            // handle errors from MoreStuffToDo()
        } 
        finally
        {
            // clean up image...
            image.Dispose();
        }
    }
