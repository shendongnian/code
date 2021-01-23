            var tiledImage = Task.Factory.ContinueWhenAll(
                images, (i) => TileImages(i));
            // We are currently on the UI thread. Save the sync context and pass it to
            // the next task so that it can access the UI control "image1".
            var UISyncContext = TaskScheduler.FromCurrentSynchronizationContext();
            //  On the UI thread, put the bytes into a bitmap and
            // and display it in the Image control.
            var t3 = tiledImage.ContinueWith((antecedent) =>
            {
                ...
                ...
            }, UISyncContext);
