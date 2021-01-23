    public IEnumerable<Recommendation> GetRecommendationByDate(DateTime startDate, DateTime? endDate) 
        {
            if (endDate == null) 
            {
                endDate = DateTime.Now;
            }
    
            var output = db.Recommendations.Where(r => r.IsPublished == true &&
                                                       r.CreatedDate.CompareTo(startDate) > 0 &&
                                                                                                                                                            endDate.HasValue && r.CreatedDate.CompareTo(endDate.Value) < 0)
                                           .ToList();
    
                return output;
            }
