            try
            {
                var uri = new Uri(parent.BaseUri, path);
                
                return uri;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
