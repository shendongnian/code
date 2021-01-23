    void RemoveExercises(UserExerciseViewModel model, int id)
    {
        var userExerciseViewModel = (UserExerciseViewModel)(Session["UserExerciseViewModel"]);
        foreach (int selected in model.RequestedSelected)
        {
            if (model.RequestedSelected != null)
            {
                User user = db.Users.Find(id);
                RegimeItem item = db.RegimeItems.Find(selected);
                item.RegimeExercise = this.GetAllExercises().FirstOrDefault(i => i.ExerciseID == selected); //--this removes the regimeexercise
                user.RegimeItems.Remove(item); //deletes the user's regimeitem
                db.RegimeItems.Remove(item); //removes the regimeitem itself 
            }
        }
        db.SaveChanges();
    }
