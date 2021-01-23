            if (schedules.Count() > 1)
            {
                doublestudents = (from s in ctx.Students
                                  where s.Courses.Any(x=> x.Key == schedules[0].Course.Key) && s.Courses.Any(x=> x.Key == schedules[1].Course.Key)
                                  select s).ToList();
                Console.WriteLine(doublestudents.Count); <<< count results in 0 students.
            }
        }
