    public ActionResult ExerciseIndex(UserExerciseViewModel model, string add, string remove, string send, int id, RegimeItem item)
        {
    
            UserExerciseViewModel model2 = (UserExerciseViewModel)(Session["UserExerciseViewModel"]);
            model.RequestedExercises = model2.RequestedExercises;
            model.AvailableExercises = model2.AvailableExercises;
            if (!string.IsNullOrEmpty(add))
                AddExercises(model, id);
            else if (!string.IsNullOrEmpty(remove))
                RemoveExercises(model, id);
            User user = db.Users.Find(id);
            return RedirectToAction("ExerciseIndex", new { id = model2.UserID, vmodel = model2 });
        }
