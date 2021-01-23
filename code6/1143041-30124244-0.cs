    public IEnumerable<TourSummaryDto> GetSearchTours(string destination, int? duration, int? price)
    {
            var query = _tourItemRepository.GetAll();
            
            query = query.Where(p => p.Category.Name.ToUpper() == destination.ToUpper();
            if (duration.HasValue)
            {
                query = query.Where(p => p.Duration == duraation.Value);
            }
            return
                ConvertToTourSummaryDtoQuery(query.OrderByDescending(t => t.CreatedDate));
    }
