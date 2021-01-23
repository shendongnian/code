        static void wlanIface_WlanNotification(Wlan.WlanNotificationData notifyData)
        {
            if (notifyData.notificationCode == (int)Wlan.WlanNotificationCodeAcm.ScanComplete)
            {
                Console.WriteLine("Scan Complete!");
            }
        }
