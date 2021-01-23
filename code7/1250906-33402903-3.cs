    [WebMethod]
        public static string SubmitTweet(string tweet)
        {
            // dummy function :
            return DataSubmit(tweet) ? "Data Was submitted" : "Error while submitting data";
        }
        
        public bool DataSubmit(string data)
        {        
            //call db connection and save the tweet
            // if successful , return true else false
        }
