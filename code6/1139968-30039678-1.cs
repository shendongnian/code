        [DataContract]
        public class CallRequest
        {
            [DataMember(Name = "from")]
            public string From { get; set; }
            [DataMember(Name = "to")]
            public string To { get; set; }
            [DataMember(Name = "answer_url")]
            public string AnswerUrl { get; set; }
        }
    I was able to generate the following JSON:
            var request = new CallRequest { AnswerUrl = "AnswerUrl", From = "from", To = "to" };
            var json = SimpleJson.SerializeObject(request);
            Debug.WriteLine(json);
            // Prints {"from":"from","to":"to","answer_url":"AnswerUrl"}
    I'm not sure how thoroughly tested this option is, however, since it's compiled out by default.
