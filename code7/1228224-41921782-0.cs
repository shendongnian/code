    string url = "http://www.youtube.com";     
    string QUrl = "https://graph.facebook.com/?fields=id,share,og_object{engagement{count},likes.summary(true).limit(0),comments.limit(0).summary(true)}&id=" + url;
            System.Net.HttpWebRequest Request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(QUrl);
            Request.ContentType = "text/json";     
            Request.Timeout = 10000;
            Request.Method = "GET"; 
            string content;
            using (WebResponse myResponse = Request.GetResponse())
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8))
                {
                    content = sr.ReadToEnd();
                }
            };
            var json = JObject.Parse(content);
            var like_count = json["og_object"]["likes"]["summary"]["total_count"];
            Console.WriteLine("Like Count :" + like_count);
            var share_count = json["share"]["share_count"];
            Console.WriteLine("Share Count :" + share_count);
            var comment_count = json["og_object"]["comments"]["summary"]["total_count"];
            Console.WriteLine("Comment Count :" + comment_count);
