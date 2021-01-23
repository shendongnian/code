    public ActionResult ClasssStatistics()
    {
        IQueryable<ClassStatistics> data = from st in db.StudentDetailss
                                           group st by st.ClasssId into classsGroup
                                    select new ClassStatistics()
                                    {
                                        ClassId = classsGroup.Key,
                                        ClassName = classsGroup.First().ClassName,
                                        ClassCount = classsGroup.Count()
                                    };
        return View(data.ToList());
    }
