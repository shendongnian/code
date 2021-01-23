    public static class Router
    {
        static frmLogin rLogin = new frmLogin();
        static frmDashboard rDashboard = new frmDashboard();
        static frmReport rReport = new frmReport();
        static readonly Dictionary<string, Action> RoutingDictionary;
        static Router()
        {
            RoutingDictionary = typeof (Router).GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                .Where(x => typeof (Form).IsAssignableFrom(x.FieldType))
                .ToDictionary(k => k.Name, v =>
                {
                    var form = v.GetValue(null);
                    return (Action) form.GetType().GetMethod("Index").CreateDelegate(typeof (Action), form);
                });
        }
        public static void Route(string form)
        {
            RoutingDictionary[form]();
        }
    }
