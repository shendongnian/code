    private static bool ValidateUrlImage(string absoluteUrl)
            {
                Uri uri;
                if (!Uri.TryCreate(absoluteUrl, UriKind.Absolute, out uri))
                {
                    return true;
                }
                using (var client = new WebClient())
                {
                    try
                    {
                        using (var stream = client.OpenRead(uri))
                        {
                            Image.FromStream(stream);
                            return true;
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
