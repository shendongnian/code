    public class ProductGrouping
    {
        public int ProductId { get; set; }
        public int? WidgetId { get; set; }
    }
    public IGrouping<ProductGrouping, Summary> GetGroupedSummaries()
    {
		return _summaryRepository.GetFilteredSummaries(...)
								 .Where(s => ...)
								 .GroupBy(s => new ProductGrouping
								 {
									ProductId = s.ProductId,
									WidgetId = model.allWidgets ? (int?)null : s.WidgetId,
								 });
    }
