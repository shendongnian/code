    public static class Employees
    {
        public static int CurrentEmployees()
        {
            return (new Func<int>(() => Employee.Load().Count(x => x.DateFinished == null && !x.Contractor && x.DateStarted < DateTime.Now)))
                .Cache("CurrentEmployees")
                .OnError(e => -1) 
                ();//TODO: log?
        }
    }
