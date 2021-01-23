    public class Review
    {
        public virtual int recordId { get; set; }
        public virtual string reviewerId { get; set; }
        public virtual string reviewerName { get; set; }
        public virtual string country { get; set; }
        public virtual string zipCode { get; set; }
        public virtual string reviewProduct { get; set; }
        public virtual string reviewText { get; set; }
        public virtual string reviewTextLanguage { get; set; }
        public virtual double sentimentScore { get; set; }
        public virtual bool isScoreRefined { get; set; }
        public virtual IList<ReviewSentences> sentences { get; set; }
    }
    
    pulic class ReviewSentences
    {
        public virtual int recordId { get; set; }
        public virtual int reviewId { get; set; }
        public virtual int sentenceId { get; set; }
        public virtual string sentence { get; set; }
        public virtual double sentimentScore { get; set; }
    }
