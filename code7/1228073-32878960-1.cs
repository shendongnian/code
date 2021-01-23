    //WebApiConfigRegister
	var progress = new ProgressMessageHandler();
	progress.HttpSendProgress += HttpSendProgress;
	config.MessageHandlers.Add(progress);
	//End WebApiConfig Register
        private static void HttpSendProgress(object sender, HttpProgressEventArgs e)
        {   
            var request = sender as HttpRequestMessage;
            //todo: check if request is not null
            //Get an Id from the client or something like this to identify the request
            var id = request.RequestUri.Query[0];
            var perc = e.ProgressPercentage;
            var b = e.TotalBytes;
            var bt = e.BytesTransferred;
            Cache.InsertOrUpdate(id, perc);
        }
