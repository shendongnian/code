    private async void btnLoad_Click(object sender, EventArgs e)
    {
        if (_loadChaptersCancelSource == null)
        {
            var wasCancelled = false;
            _loadChaptersCancelSource = new CancellationTokenSource();
            try
            {
                var token = _loadChaptersCancelSource.Token;
                foreach (var item in myCollectionOfUrls)
                {
                    // stop if cancellation was requested.
                    token.ThrowIfCancellationRequested();
                    Uri tempUri = new Uri(item);
                    Uri = tempUri; // Uri is a property
                    // also modified to be cancellable.
                    string htmlCode = await LoadHtmlCodeAsync(Uri, token); 
                    // client decides to run as a background task
                    var newChapters = await Task.Run(() =>  
                        LoadAllChapters(htmlCode, Path.GetFileNameWithoutExtension(item), token), 
                        token);
                    Chapters.AddRange(newChapters);
                }
            }
            catch (OperationCanceledException) 
            { 
                wasCancelled = true;
            }
            catch (AggregateException ex) 
            {
                if (!ex.InnerExceptions.Any(e => typeof(OperationCanceledException).IsAssignableFrom(e.GetType())))
                    throw; // not cancelled, different error.
                wasCancelled = true;
            }
            finally
            {
                var cts = _loadChaptersCancelSource;
                _loadChaptersCancelSource = null;
                cts.Dispose();
            }
            if (wasCancelled)
                ; // Show a message ?
        }
    }
