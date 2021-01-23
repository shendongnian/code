    [HttpPost]
    public ActionResult EditFirstCharac(EditCharacViewModel vm)
    {
        if (ModelState.IsValid)
        {
            // OK, save to DB or whatever and Redirect to a GET action (PRG pattern)
        }
        //Reload data
        vm.PossibleAnswers = charac.Question.PossibleAnswers
                            .ToListSelectListItem(p => p.Id.ToString(), p => p.Label).ToList();
        return View("Edit", vm);
    }
