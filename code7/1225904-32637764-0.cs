        private static async void EventStreaming()
        {
            EventStreamResponse response = await FirebaseHelper.Client.OnAsync("emails",
            added: (sender, args) =>
            {
                Debug.WriteLine("ADDED " + args.Data + " -> 2\n");
            },
            changed: (sender, args) =>
            {
                Debug.WriteLine("CHANGED " + args.Data);
            },
            removed: (sender, args) =>
            {
                Debug.WriteLine("REMOVED " + args.Path);
            });
            //Call dispose to stop listening for events
            //response.Dispose();
        }
