        using Spring.Social.Dropbox.Api;
        using Spring.Social.Dropbox.Connect;
        using Spring.Social.OAuth1;
        private void ShareViaDropbox(string[,] filesNameLink)
        {
            try
            {
                if (CheckForInternetConnection()) // cant use dropbox without internet.
                {
                    string consumerKey = "<get this from dropbox>";
                    string consumerSecret = "<get this from dropbox>";
                    DropboxServiceProvider dropboxServiceProvider = new DropboxServiceProvider(consumerKey, consumerSecret, AccessLevel.Full);
                    IOAuth1Operations oauthOperations = dropboxServiceProvider.OAuthOperations;
                    // I used an xml file to store the key (probably not the most secure later I will write an encryption).
                    string[] storedToken = GetTag("<DropBoxToken>", ",").Split(','); 
                    OAuthToken oauthAccessToken = new OAuthToken(storedToken[0], storedToken[1]);
                    // testing if we got something from the earlier xml tag.
                    if (oauthAccessToken.Value == string.Empty || oauthAccessToken.Value == "") 
                    {
                        Console.Write("Getting request token...");
                        OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
                        Console.WriteLine("Done");
                        OAuth1Parameters parameters = new OAuth1Parameters();
                        string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(oauthToken.Value, parameters);
                        
                        Console.WriteLine("Redirect user for authorization");
                        
                        // let the user know they have to sign in and chose the correct dropbox. this is also where most documentation leaves off! 
                        MessageBox.Show(
                            "This is the first time you have connected to DropBox. A browser will open and direct you the the DropBox authentication page. When you prompted, please sign in and then choose the [named] DropBox." + Environment.NewLine +
                            "Once you have succesfully compleaded the authorization confirmation from DropBox, you may close the browser to continue." + Environment.NewLine +
                            Environment.NewLine +
                            "Click 'Ok' to proceed", "DropBox Authentication Required.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(authenticateUrl);
                        // halt the program until the user has authenticated.
                        MessageBox.Show("Click 'OK' when authorization has succeeded.", "DropBox Authentication - WAIT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Console.Write("Press any key when authorization attempt has succeeded");
                        Console.Write("Getting access token...");
                        AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
                        oauthAccessToken = dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
                        Console.WriteLine("Done");
                        ChangeTag("<DropBoxToken>", oauthAccessToken.Value + "," + oauthAccessToken.Secret); // update the xml file with the token.                        
                    }
                    IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);
                    DropboxLink shareableLink;
        
                    // remove everything before the users special folder path including the dropbbox folder.
                    // then change all the switches to front from back for the web.
                    for (int i = 0; i < filesNameLink.Length; i++)
                    {
                        filesNameLink[i,0] = Path.GetFileName(filesNameLink[i,0]);
                        filesNameLink[i,1] = filesNameLink[i,0].Replace(dropboxRootDir, "").Replace("\\", "/");
                        // here is your shareable link, also using 'dropbox' you can now actually rename, copy, delete, or move the file.
                        shareableLink = dropbox.GetShareableLinkAsync(filesNameLink[i,0].Replace("\\", "/")).Result;
                        filesNameLink[i,1] = shareableLink.Url;
                    }
                    // do something with the link(s). //
                    catch { }
                }
            }
            catch { }
        }       
