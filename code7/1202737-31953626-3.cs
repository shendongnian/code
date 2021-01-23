    public ActionResult Edit(List<OptionVM> model)
    {
      // for example, get the answers where the checkbox has been selected
      var selectedAnswers = model.Where(m => m.IsSelected).Select(m => m.Answer);
    }
