    [HttpPost]
    public ActionResult(ProjectEditModel model, List<ProjectIdea> collection)
    {
      model.Ideas = collection;
      ...
