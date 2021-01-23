    /// <summary>
        /// Used for accessing public api data. 
        /// </summary>
        /// <param name="apiKey">Public API key from Google Developers console</param>
        /// <returns>a valid WebfontsService</returns>
        public static WebfontsService AuthenticatePublic(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new Exception("apiKey is required.");
            try
            {
                // Create the service.
                var service = new WebfontsService(new BaseClientService.Initializer()
                {
                    ApiKey = apiKey,
                    ApplicationName = "Webfonts Authentication Sample",
                });
                return service;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw ex;
            }
        }
