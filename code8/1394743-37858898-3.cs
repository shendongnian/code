    [assembly: Dependency(typeof(DeviceInfoServiceImplementation))]
    namespace WinPhone.Services
    {
        public class DeviceInfoServiceImplementation : IDeviceInfoService
        {
            public string ConvertToDeviceShortDateFormat(DateTime inputDateTime)
            {
                return inputDateTime.ToShortDateString();
            }
    
            public string ConvertToDeviceTimeFormat(DateTime inputDateTime)
            {
                return inputDateTime.ToShortTimeString();
            }
        }
    }
