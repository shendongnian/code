        /// <summary>
        /// Used to handle the api response
        /// </summary>
        /// <param name="response">The HttpResponseMessage</param>
        /// <returns>Returns a string</returns>
        private async Task<string> HandleResponse(HttpResponseMessage response)
        {
            // Read our response content
            var result = await response.Content.ReadAsStringAsync();
            // If there was an error, throw an HttpException
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ApiException(result);
            // Return our result if there are no errors
            return result;
        }
