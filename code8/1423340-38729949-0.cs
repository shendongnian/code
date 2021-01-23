    public void SetCustomError()
        {
            var errors = new List<string>();
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            foreach (var error in errors)
            {
                ModelState.AddModelError("CustomError", error);
            }
        }
