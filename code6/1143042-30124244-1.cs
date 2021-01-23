    public IEnumerable<TourSummaryDto> GetSearchTours(string destination, int? duration, int? price)
    {
            var query = _tourItemRepository.GetAll();
            
            //always has a destination
            query = query.Where(p => p.Category.Name.ToUpper() == destination.ToUpper();
            //filter results that also have the given duration, only if a value is provided.
            if (duration.HasValue)
            {
                query = query.Where(p => p.Duration == duration.Value);
            }
            return
                ConvertToTourSummaryDtoQuery(query.OrderByDescending(t => t.CreatedDate));
    }
