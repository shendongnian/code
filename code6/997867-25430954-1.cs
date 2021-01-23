    class Result
        {
            private List<Review> _Reviews = new List<Review>();
            public List<Review> Reviews { get { return _Reviews; } }
    
            public void Add(Review r)
            {
                if (_Reviews.Contains(r))
                {
                    //check if difference on Amount
                    int index = _Reviews.IndexOf(r);
                    Review currentReview = _Reviews[index];
    
                    if (currentReview.Amount < r.Amount)
                    {
                        //replace
                        _Reviews.RemoveAt(index);
                        _Reviews.Add(r);
                    }
                    //else keep existing
                }
                else
                {
                    //Add
                    _Reviews.Add(r);
                }
            }
        }
