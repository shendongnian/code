        /// <summary>
        /// Debugging method to get the json that was sent to ES
        /// </summary>
        public static string GetRequestString(this IResponse response)
        {
            var request = response.RequestInformation.Request;
            if (request != null)
            {
                return Encoding.Default.GetString(request);
            }
            return response.RequestInformation.RequestUrl;
        }
