    @using (Html.BeginForm("Search", "Inquiry", FormMethod.Post))
    {
        @Html.LabelFor(m => m.HouseTag)
        @Html.TextBoxFor(m => m.HouseTag, new { type = "Search", autofocus = "true", style = "width: 200px", @maxlength = "6" })
    
        <input type="submit" value="Search" id="submit" />
    }
    [HttpPost]
    public ActionResult Search(Search model){
        ViewBag.Tag = model.HouseTag;
        return View();
    }
