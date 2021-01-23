    @Html.ActionLink("Vælg", "GetSeatsInShow", new { id = item.Id })
    [HttpPost]
    public ActionResult GetSeatsInShow(int id)
    {
        ...
        return View(realSeatList);
    }
