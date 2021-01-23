     void RemoveExercises(UserExerciseViewModel model, int id)
        {
            var userExerciseViewModel = (UserExerciseViewModel)(Session["UserExerciseViewModel"]);
            foreach (int selected in model.RequestedSelected)
            {
                RegimeItem item = model.RequestedExercises.FirstOrDefault(i => i.RegimeItemID == selected);
                if (item != null)
                {
                    model.RequestedExercises.Remove(item);
                }
            }
            db.SaveChanges(); // What is the point of this? You didn't alter the user?
        }
