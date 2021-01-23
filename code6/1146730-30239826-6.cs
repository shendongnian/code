    void RestoreSavedState(UserExerciseViewModel model, User user)
    {
        user.RegimeItems = model.RequestedExercises;
        //get the previously stored items
        if (!string.IsNullOrEmpty(model.SavedRequested))
        {
            string[] exIds = model.SavedRequested.Split(',');
            var regimeItems = ChosenExercises(user, model).Where(p => exIds.Contains(p.RegimeItemID.ToString()));
            model.RequestedExercises.AddRange(regimeItems);
        }
    }
