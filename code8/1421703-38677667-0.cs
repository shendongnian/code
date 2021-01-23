        IEnumerable<string> itemsList = new[] { "Ana", "are", "mere", "pere", "papaia", "Aaa", "Ab", "An" };
        IEnumerable<string> filteredResults = null;
        if (string.IsNullOrEmpty(term))
        {
            filteredResults = itemsList;
        }
        else
        {
            filteredResults = itemsList.Where(s => s.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0);
        }
        return Json(filteredResults, JsonRequestBehavior.AllowGet);
    }
