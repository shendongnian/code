            public static Platform DetectaPlataforma()
        {
            if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                (App.Current as App).Telefone = true;
                return Platform.WindowsPhone;
            }
            else
            {
                (App.Current as App).Telefone = false;
                return Platform.Windows;
            }
        }
