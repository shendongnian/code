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
