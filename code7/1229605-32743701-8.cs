    public class OfferTitleFilenameDTO
    {
        public string Title {get;set;}
        public string Filename {get;set;}
    }
 
    public PartialViewResult Category()
    {
        var offers = db.Offers.Select<Offer, IQueryable<OfferTitleFilenameDTO>>( (entity) => entity.FilePaths.Select<FilePath, OfferTitleFilenameDTO>(filePath => new OfferTitleFilenameDTO() {
                Filename = filePath.FileName,
                Title = entity.Title
            })
        });
 
        return PartialView("_OfferBoxList", offers.SelectMany(dtos => dtos));
    }
    @foreach (var item in Model) // Model is presumably OfferTitleFilenameDTO
    {
        @item.Title 
        @item.Filename 
    }
