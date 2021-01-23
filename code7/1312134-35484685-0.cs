        _channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
        _channel.PushNotificationReceived += OnPushNotificationReceived;
       private void OnPushNotificationReceived(PushNotificationChannel sender, PushNotificationReceivedEventArgs args)
        {
            switch (args.NotificationType)
            {
                case PushNotificationType.Badge:
                    this.OnBadgeNotificationReceived(args.BadgeNotification.Content.GetXml());
                    break;
                case PushNotificationType.Tile:
                    this.OnTileNotificationReceived(args.TileNotification.Content.GetXml());
                    break;
                case PushNotificationType.Toast:
                    this.OnToastNotificationReceived(args.ToastNotification.Content.GetXml());
                    break;
                case PushNotificationType.Raw:
                    this.OnRawNotificationReceived(args.RawNotification.Content);
                    break;
            }
            args.Cancel = true;
        }
        private void OnBadgeNotificationReceived(string notificationContent)
        {
            // Code when a badge notification is received when app is running
        }
        private void OnTileNotificationReceived(string notificationContent)
        {
            // Code when a tile notification is received when app is running
        }
        private void OnToastNotificationReceived(string notificationContent)
        {
            // Code when a toast notification is received when app is running
            // Show a toast notification programatically
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(notificationContent);
            var toastNotification = new ToastNotification(xmlDocument);
            //toastNotification.SuppressPopup = true;
            ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
        }
        private void OnRawNotificationReceived(string notificationContent)
        {
            // Code when a raw notification is received when app is running
        }
