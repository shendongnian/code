        public new IAsyncOperation<ContentDialogResult> ShowAsync()
        {
            var tcs = new TaskCompletionSource<ContentDialogResult>();
            CaptionTB.KeyDown += (sender, args) =>
            {
                if (args.Key != VirtualKey.Enter) return;
                tcs.TrySetResult(ContentDialogResult.Primary);
                Hide();
            };
            var asyncOperation = base.ShowAsync();
            asyncOperation.AsTask().ContinueWith(task => tcs.TrySetResult(task.Result));
            return tcs.Task.AsAsyncOperation();
        }
