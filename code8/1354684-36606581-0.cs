    public class ReviewComparer : IEqualityComparer<Review>
    {
        public bool Equals(Review x, Review y)
        {
            return x.ReviewID == y.ReviewID;
        }
    
        public int GetHashCode(Review rv)
        {
            return rv.ReviewID.GetHashCode();
        }
    }
