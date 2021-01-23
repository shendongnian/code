            if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)
            {
                if (PostData.Substring(0, 1) != "<")
                    request.ContentType = "application/json";
                Console.WriteLine("Content type is " + request.ContentType.ToString());
                request.ContentLength = PostData.Length;
                using (var postStream = new StreamWriter(request.GetRequestStream()))
                {
                    postStream.Write(PostData);
                }
            }
