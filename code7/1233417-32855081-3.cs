    public IEnumerable<TrainingCourse> TrainingCourses
    {
        get
        {
            return _trainingCourses
                .Where(tc => tc.IsActive)
                .AsEnumerable();
        }
    }
