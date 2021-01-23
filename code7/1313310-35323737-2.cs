    public class WatsonVRClassifiersResponse
    {
        [JsonProperty("classifiers")]
        public WatsonVRClassifier[] Classifiers { get; set; }
        public WatsonVRClassifiersResponse()
        {
            Classifiers = new WatsonVRClassifier[0];
        }
    }
