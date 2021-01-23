    public IEnumerable<Recommendation> GetRecommendationByDate(DateTime startDate, DateTime? endDate) 
        {
            if (endDate == null) 
            {
                endDate = DateTime.Now;
            }
    
            var output = db.Recommendations.Where(r => r.IsPublished == true &&
                                                       r.CreatedDate.CompareTo(startDate) > 0 &&
                                                       r.CreatedDate.CompareTo(endDate.HasValue ? endDate.Value : (The default you want to put when endDate is null)) < 0)
                                           .ToList();
    
                return output;
            }
