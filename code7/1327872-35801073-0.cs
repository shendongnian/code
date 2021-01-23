        public ViewResult Unassigned()
        {
            PatrolUnassignedViewModel unassinged = new PatrolUnassignedViewModel();
            unassinged.Patrols = new SelectList(repository.SelectAllPatrols());
            unassinged.Scout = repository.SelectAllUnassigned();
            return View(unassinged);
        }
