    public ActionResult MyCtroller(myViewModel model)
    {
        //processing stuff
        JsonResultObject result = new JsonResultObject();
        try
        {
           //return secess
        }
        catch (Exception ex)
        {
           //return error
        }
        SearchCriteria<MyModel> viewModel = new SearchCriteria<MyModel>();
        viewModel.SortExpression = m => m.OrderByDescending(a => a.Date);
        SearchResult<MyModel> searchResult = MyModelService.Instance.Search(viewModel);
        // result.PartialViewHtml = RenderPartialViewToString("PartialView.cshtml", searchResult);
        // If you want to render as html partial view
        
        return PartialView("PartialView.cshtml", searchResult);
        // return Json(result));
    }
