        internal static string Response(HttpWebRequest webRequest)
        {
            var asyncResult = webRequest.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();
            using (var webResponse = webRequest.EndGetResponse(asyncResult))
            {
                var responsesteam = webResponse.GetResponseStream();
                if (responsesteam == null) return default(string);
                using (var rd = new StreamReader(responsesteam))
                {
                    var soapResult = rd.ReadToEnd();
                    return soapResult;
                }
            }
        }
