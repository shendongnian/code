    [Serializable]
    public class Questions
    {
        public string id;
        public string question;
        public string answer1;
        public string answer2;
    }
    
    [Serializable]
    public class QuestionList
    {
        public List<Questions> list;
    }
    
    //and
    
    var jstring = "{\"list\":[{\"id\":\"1\",\"question\":\"lorem Ipsome \",\"answer1\":\"yes\",\"answer2\":\"no\"},{\"id\":\"2\",\"question\":\"lorem Ipsome Sit dore iman\",\"answer1\":\"si\",\"answer2\":\"ne\"}]}";
    
    var result = JsonUtility.FromJson<QuestionList>(jstring);
