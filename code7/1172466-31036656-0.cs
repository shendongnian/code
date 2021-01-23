     var data = dt.AsEnumerable();
        var sections = data
            .GroupBy(r => new { ID = r["SectionId"] }).Select(c => new Chapter
            {
                Id = (int)c.Select(n => n["SectionId"]).FirstOrDefault(),
                Name = (string)c.Select(n => n["Section"]).FirstOrDefault(),
                Lessons = new List<Lesson>()
            }).Distinct().ToList();
        var lessons = data
            .GroupBy(r => new { ID = r["LessonId"] }).Select(l => new Lesson
            {
                Id = (int)l.Select(n => n["LessonId"]).FirstOrDefault(),
                Name = l.Select(n => n["Lesson"]).FirstOrDefault().ToString(),
                Activities = new List<Activity>(),
                ChapterId = (int)l.Select(n => n["SectionId"]).FirstOrDefault()
            }).Distinct().ToList();
        var activities = data
            .Select(a => new Activity
            {
                Name = (string)a["Activity"],
                Date = (string)a["Date"],
                Time = (string)a["Time"],
                Score = (int)a["Score"],
                Duration = (int)a["Duration"],
                LessonId = (int)a["Lessonid"]
            }).ToList();
        foreach (var lesson in lessons)
        {
            var activitiesToAdd = activities.Where(a => a.LessonId == lesson.Id);
            lesson.Activities.AddRange(activitiesToAdd);
        }
        foreach (var section in sections)
        {
            var lessonsToAdd = lessons.Where(l => l.SectionId == section.Id);
            section.Lessons.AddRange(lessonsToAdd);
        }
