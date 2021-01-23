    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => Response.AsFile(Settings.Instance.GetFullContentPath("index.html"));
        }
    }
