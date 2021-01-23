    public static Stream LoadGridStatus()
    {
        using (MyEntities context = new MyEntities())
        {
            TestViewStatus t = (from d in context.TestViewStatuses
                    select d).FirstOrDefault();
            return t.GridStatus;
        }
    }
