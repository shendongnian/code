    public async Task<ActionResult> Index(SearchViewModel postData) {
        if (!ModelState.IsValid) {
            // error handling, e.g. return View Index again (errors will already have been added)
        }
        // no error -> continue
    }
