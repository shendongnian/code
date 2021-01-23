    public class OfferDTO
    {
        public int OfferID { get; set; }
        public string Reference { get; set; }
        public string Title { get; set; }
        public IEnumerable<FilePath> FilePaths { get; set; }
    }
---
    public PartialViewResult Category()
    {
        var offers = db.Offers.Select<Offer, OfferDTO>( (entity) => new OfferDTO() {
            OfferID = entity.OfferID,
            Reference = entity.Reference,
            Title = entity.Title,
            FilePaths = entity.FilePaths.AsEnumerable()
        });
 
        return PartialView("_OfferBoxList", offers.ToList());
    }
