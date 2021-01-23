    // This is NOT best-practice code, just showing a demo of an Jcifs api call
    public async Task getFileContents ()
    {
        await Task.Run (() => {
            var smbStream = new SmbFileInputStream ("smb://guest@10.10.10.5/code/test.txt");
            byte[] b = new byte[8192];
            int n;
            while ((n = smbStream.Read (b)) > 0) {
                Console.Write (Encoding.UTF8.GetString (b).ToCharArray (), 0, n);
            }
            Button button = FindViewById<Button> (Resource.Id.myButton);
            RunOnUiThread(() => {
                button.Text = Encoding.UTF8.GetString (b);
            });
        }
        ).ContinueWith ((Task arg) => {
            Console.WriteLine (arg.Status);
            if (arg.Status == TaskStatus.Faulted)
                Console.WriteLine (arg.Exception);
        }
        );
    }
