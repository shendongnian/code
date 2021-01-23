    var query = from a in UnitOfWork.ActivityLessonParticipantService.Query
                 where a.ActivityLesson.Activity.Id == activityId
                    && a.ActivityLesson.From >= startDate 
                    && (a.ActivityLesson.To == startDate || a.ActivityLesson.To <= endDate)
                    && !a.ActivityLesson.IsDeleted 
                    && !a.ActivityLesson.Activity.IsDeleted 
                    && a.Appeared
                 select a;
    var firstByDate = query.GroupBy(a => a.ActivityLesson.From.Date)
        .Select(grp => grp.OrderBy(a => a.ActivityLesson.From).First())
        .OrderBy(a => a.User.UserName)
        .Select(a => new
        {
            CPR = a.User.UserName,
            FullName = a.User.FullName,
            ActivityFromDate = a.ActivityLesson.From,
        }).ToList();
