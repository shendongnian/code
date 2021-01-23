        using(var stream = await audioFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
        {
            // play dat funky music
            MediaElement mediaplayer = new MediaElement();
            mediaplayer.SetSource(stream, audioFile.ContentType);
            
            var tcs = new TaskCompletionSource<bool>();
            mediaplayer.CurrentStateChanged += (o,e) =>
            {
                if (mediaplayer.CurrentState != MediaElementState.Opening && 
                    mediaplayer.CurrentState != MediaElementState.Playing && 
                    mediaplayer.CurrentState != MediaElementState.Buffering &&
                    mediaplayer.CurrentState != MediaElementState.AcquiringLicense)
                    {
                        // Any other state should mean we're done playing
                        tcs.TrySetResult(true);
                    }
            };
            mediaplayer.Play();
            await tcs.Task; // Asynchronously wait for media to finish
        }
    }
