    class Program
        {
            static void Main(string[] args)
            {
                List<Application> application = new List<Application>();
                List<Hazard> hazard = new List<Hazard>();
                int appID = 1;
                int hazID = 1;
                for (int i = 0; i < 10; i++)
                {
                    application.Add(new Application() { AppID = appID, AppName = string.Format("AppName{0}", i + 1) });
                    hazard.Add(new Hazard() { HazID = hazID, AppID = appID, HazName = string.Format("HazName{0}", hazID) });
                    hazID++;
                    hazard.Add(new Hazard() { HazID = hazID, AppID = appID, HazName = string.Format("HazName{0}", hazID) });
                    hazID++;
                    appID++;
                }
    
                List<AppHaz> appHaz = (from app in application
                                       select new AppHaz { AppID = app.AppID, Hazards = (from haz in hazard where haz.AppID == app.AppID select haz).ToList() }).ToList();
    
            }
        }
    
        class Application
        {
            public int AppID { get; set; }
            public string AppName { get; set; }
        }
    
        class Hazard
        {
            public int HazID { get; set; }
            public int AppID { get; set; }
            public string HazName { get; set; }
        }
    
        class AppHaz
        {
            public int AppID { get; set; }
            public List<Hazard> Hazards { get; set; }
        }
