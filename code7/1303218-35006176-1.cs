    public ActionResult GetStateLinks()
        {
            var stateLink = new List<string>();
            var model = rr.RetrieveStateLinks("2014").Select(m=> m.UrlLink).ToList();
            foreach (var s in model)
            {
                stateLink.Add(s);
            }
    
            var rm = new LinkModels();
            rm.LinkState = "foo";
            rm.ListOfUrls = stateLink;
    
            return View(rm);
        }
    @foreach (var item in Model.StateLinkList)
    {
       <td>
            <a href="@item">@Model.LinkState</a>
       </td>
    }
