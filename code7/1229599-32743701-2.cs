    public class OfferDTO
    {
        public int OfferID { get; set; }
        public string Reference { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> FileNames { get; set; }
    }
---
    public PartialViewResult Category()
    {
        var offers = db.Offers.Select<Offer, OfferDTO>( (entity) => new OfferDTO() {
            OfferID = entity.OfferID,
            Reference = entity.Reference,
            Title = entity.Title,
            FileNames = entity.FilePaths.Select<FilePath, string>( filePath => filePath.FileName).AsEnumerable()
        });
 
        return PartialView("_OfferBoxList", offers.ToList());
    }
