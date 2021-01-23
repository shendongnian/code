        void Share(string sharingUrl)
        {
            var content = new ShareLinkContent();
            content.SetContentUrl(new NSUrl(sharingUrl));
            var shareDialog = new FacebookShareDialog
                                  {
                                      FromViewController = UIApplication.SharedApplication.KeyWindow.RootViewController,
                                      Mode = ShareDialogMode.Native
                                  };
            shareDialog.SetShareContent(content);
            shareDialog.Show();
        }
