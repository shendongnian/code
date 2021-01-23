    var mResumableUploader = new ResumableUploader(chunkSize);
            mResumableUploader.AsyncOperationCompleted += MResumableUploaderAsyncOperationCompleted;
            mResumableUploader.AsyncOperationProgress += MResumableUploaderAsyncOperationProgress;
    mResumableUploader.AsyncOperationCompleted += new AsyncOperationCompletedEventHandler(ru_AsyncOperationCompleted);
            var youTubeAuthenticator = new ClientLoginAuthenticator(appName, ServiceNames.YouTube, uName, passWord);
            youTubeAuthenticator.DeveloperKey = devKey;
    
            newVideo = new Video();
    
            newVideo.Title = "video";
            newVideo.Tags.Add(new MediaCategory("Entertainment", YouTubeNameTable.CategorySchema));
            newVideo.Keywords = "video";
            newVideo.Description = "video";
            newVideo.YouTubeEntry.Private = false;
            newVideo.YouTubeEntry.MediaSource = new MediaFileSource(fileName, fileContType);
    
            var link = new AtomLink("http://uploads.gdata.youtube.com/resumable/feeds/api/users/default/uploads");
            link.Rel = ResumableUploader.CreateMediaRelation;
            newVideo.YouTubeEntry.Links.Add(link);
    
            Console.WriteLine("Starting upload: ");
            mResumableUploader.InsertAsync(youTubeAuthenticator, newVideo.YouTubeEntry, "inserter");
