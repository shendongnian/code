    interface IAction
    {
        void Add<T>(params T[] t) where T : IModel;
    }
    
    class IModel
    {
    }
    
    class TopicModel : IModel
    {
        public string Id { get; set; }
        public string Author { get; set; }
    }
    
    class CommentModel : IModel
    {
        public string Id { get; set; }
        public string Content { get; set; }
    }
    
    class Topic : IDisposable, IAction
    {
        public void Add<T>(params T[] t) where T : IModel
        {
            var topic = t[0] as TopicModel;
            var comment = t[1] as CommentModel;
    
            Console.WriteLine("Topic witch ID={0} added",topic.Id);
            Console.WriteLine("Commment witch ID={0} added", comment.Id);
        }
    
        public void Dispose()
        {
             
        }
    }
    
    class Program
    {
        static void Main()
        {
            TopicModel t = new TopicModel { Id = "T101", Author = "Harry" };
            CommentModel c = new CommentModel { Id = "C101", Content = "Comment 01" };
    
            using (var topic = new Topic())
            {
                topic.Add<IModel>(t, c);
            }
    
            Console.ReadLine();
        }
    }
