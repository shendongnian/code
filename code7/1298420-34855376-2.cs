    public class Alert
    {
        public AlertType Type { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
    }
    
    public enum AlertType
    {
        Info,
        Success,
        Warning,
        Error
    }
BaseController.cs
    public override void OnActionExecuting(ActionExecutingContext context)
        {            
            GenerateNotifications();    
            
            base.OnActionExecuting(context);
        }
    public void CreateNotification(Notification.AlertType type, string message, string title = "")
        {
            Notification.Alert toast = new Notification.Alert();
            toast.Type = type;
            toast.Message = message;
            toast.Title = title;
            List<Notification.Alert> alerts = new List<Notification.Alert>();
            if (this.TempData.ContainsKey("alert"))
            {
                alerts = JsonConvert.DeserializeObject<List<Notification.Alert>>(this.TempData["alert"].ToString());
                this.TempData.Remove("alert");
            }
            alerts.Add(toast);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            string alertJson = JsonConvert.SerializeObject(alerts, settings);
            this.TempData.Add("alert", alertJson);
        }
        public void GenerateNotifications()
        {
            if (this.TempData.ContainsKey("alert"))
            {               
                ViewBag.Notifications = this.TempData["alert"];
                this.TempData.Remove("alert");
            }
        }
Layout.cshtml
    @if (ViewBag.Notifications != null)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };
        List<Notification.Alert> obj = JsonConvert.DeserializeObject<List<Notification.Alert>>(ViewBag.Notifications, settings);
        foreach (Notification.Alert notification in obj)
        {
            switch (notification.Type)
            {
                case Notification.AlertType.Success:
                    <script type="text/javascript">toastr.success('@notification.Message', '@notification.Title');</script>
                    break;
                case Notification.AlertType.Error:
                    <script type="text/javascript">toastr.error('@notification.Message', '@notification.Title');</script>
                    break;
                case Notification.AlertType.Info:
                    <script type="text/javascript">toastr.info('@notification.Message', '@notification.Title');</script>
                    break;
                case Notification.AlertType.Warning:
                    <script type="text/javascript">toastr.warning('@notification.Message', '@notification.Title');</script>
                    break;
            }
        }
    }
