    public class HyperlinkDataModel
    {
        public string LinkText { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
    }
    @Html.MenuItem("Events", "Index", "Events", 
        new[] {
            new HyperlinkDataModel {
                ActionName = "FirstEvent", ControllerName = "Events", LinkText = "First Event" 
            }, 
            new HyperlinkDataModel {
                ActionName = "SecondEvent", ControllerName = "Events", LinkText = "Second Event"
            }
        })
