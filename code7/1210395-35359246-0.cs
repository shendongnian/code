        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            //Get the file extension
            string fileExt= Path.GetExtension(app.Request.Url.AbsolutePath);
            //Check if the extension is mp4
            bool requestForMP4 = fileExt.Equals(".mp4", StringComparison.InvariantCultureIgnoreCase);
            //If the request is not for an mp4 file, we have nothing to do here
            if (!requestForMP4)
                return;
            //Initially assume no access to media 
            bool allowAccessToMedia = false;
            //....
            // Logic to determine access
            // If allowed set allowAccessToMedia = true
            // otherwise, just return
            //....
            if(!allowAccessToMedia)
            {
                //Terminate the request with HTTP StatusCode 403.2 Forbidden: Read Access Forbidden
                app.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                app.Response.SubStatusCode = 2;
                app.CompleteRequest();
            }
        }
