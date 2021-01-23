    public class Article
    {
        public Dictionary<int, List<int>> articleComments = new Dictionary<int, List<int>>();
    
        public void AddComment(int titleNum, string comment)
        {
            if (!articleComments.ContainsKey(titleNum))
            {
                articleComments.Add(titleNum, new List<int>());
            }
            articleComments[titleNum].Add(comment);
        }
        public List<string> GetComment(int titleNum)
        {
            if (articleComments.ContainsKey(titleNum)
            {
                return articleComments[titleNum];
            }
            return null;
        }
    }
