    public ActionResult newEmail()
        {
            var emails = new Person().Emails;
            return PartialView("~/Views/Shared/EditorTemplates/string.cshtml", emails);
        }
