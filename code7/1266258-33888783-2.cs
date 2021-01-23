     var service =  StandardGoogleAuth.AuthenticatePublic("Your Public API key");
    
                var result = WebfontsSample.list(service);
    
                if (result.Items != null)
                {
                    foreach (var font in result.Items)
                    {
                        Console.WriteLine(font.Family);
                    }
                }
