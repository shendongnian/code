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
