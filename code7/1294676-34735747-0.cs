    [Route("/feedback", "POST")]
    public class GiveFeedback : IReturn<FeedbackDTO>
    {
        public string Uuid { get; set; }
        public string Content { get; set; }
    }
