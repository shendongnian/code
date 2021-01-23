    public class LinkRepository
    {
        private readonly LinkLibrary _entities = new LinkLibrary ();
    
    
        public LinkRepository()
        {
            _entities = new LinkLibrary ();
        }
    
    
        public List<LinkModels> RetrieveStateLink(string year)
        {
            return
                _entities.vw_URLLibrary.Where(s => s.YEAR.Equals(year) && s.URL_TYPE.Equals("United States")).Select(m => new LinkModels()
                {
                    LinkState = m.LinkState,
                    UrlLink = m.LinkLocation
                }).ToList();
        }
    }
    public ActionResult GetStateLinks()
        {
            var stateLink = new List<LinkModels>();
            var model = rr.RetrieveStateLinks("2014");
    
            return View(model);
        }
    @foreach (var item in Model)
            {
                <td>
                    <a href="@item.UrlLink">@item.LinkState</a>
                </td>
            }
