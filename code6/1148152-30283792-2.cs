    void AddExercises(UserExerciseViewModel model, int id)
        {
            var userExerciseViewModel = (UserExerciseViewModel)(Session["UserExerciseViewModel"]);
            foreach (int selected in model.AvailableSelected)
            {
                if (model.AvailableSelected != null)
                {
                    User user = db.Users.Find(id);
                    user.RegimeItems.Add(new RegimeItem()
                    {
                        RegimeExercise = (this.GetAllExercises().FirstOrDefault(i => i.ExerciseID == selected))
                    });
                }
            }
            db.SaveChanges(); // db is updated but your model isn't
        }
