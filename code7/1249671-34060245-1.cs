    using System;
    using System.Collections.ObjectModel;
    using System.Management;
    using System.Windows;
    
    namespace Agent.cls
    {
        public class Hw
        {
            int DeviceId;
            bool AcceptPause;
            bool AcceptStop;
            string Caption;
            string CreationClassName;
            string Description;
            bool DeskTopInteract;
            string DisplayName;
            string ErrorControl;
            int ExitCode;
            DateTime InstallDate;
            string Name;
            string PathName;
            int ServiceSpecificExitCode;
            string ServiceType;
            bool started;
            string StartMode;
            string StartName;
            string State;
            string Status;
            string SystemCreationClassName;
            string SystemName;
            int TagId;
    
            public static ObservableCollection<Hw> GetDevices()
            {
                var deviceList = new ObservableCollection<Hw>();
                try
                {
                    var query = new SelectQuery("Win32_SystemDriver");
                    var seracher = new ManagementObjectSearcher(query);
    
                    var counter = 0;
                    foreach (var wmiObject in seracher.Get())
                    {
                        var newDevice = new Hw
                        {
                            DeviceId = counter,
                            AcceptPause = Convert.ToBoolean(wmiObject["AcceptPause"]),
                            AcceptStop = Convert.ToBoolean(wmiObject["AcceptStop"]),
                            Caption = Convert.ToString(wmiObject["Caption"]),
                            CreationClassName = Convert.ToString(wmiObject["CreationClassName"]),
                            Description = Convert.ToString(wmiObject["Description"]),
                            DeskTopInteract = Convert.ToBoolean(wmiObject["DeskTopInteract"]),
                            DisplayName = Convert.ToString(wmiObject["DisplayName"]),
                            ErrorControl = Convert.ToString(wmiObject["ErrorControl"]),
                            ExitCode = Convert.ToInt16(wmiObject["ExitCode"]),
                            InstallDate = Convert.ToDateTime(wmiObject["InstallDate"]),
                            Name = Convert.ToString(wmiObject["Name"]),
                            PathName = Convert.ToString(wmiObject["PathName"]),
                            ServiceSpecificExitCode = Convert.ToInt16(wmiObject["ServiceSpecificExitCode"]),
                            ServiceType = Convert.ToString(wmiObject["ServiceType"]),
                            started = Convert.ToBoolean(wmiObject["Started"]),
                            StartMode = Convert.ToString(wmiObject["StartMode"]),
                            StartName = Convert.ToString(wmiObject["StartName"]),
                            State = Convert.ToString(wmiObject["State"]),
                            Status = Convert.ToString(wmiObject["Status"]),
                            SystemCreationClassName = Convert.ToString(wmiObject["SystemCreationClassName"]),
                            SystemName = Convert.ToString(wmiObject["SystemName"]),
                            TagId = Convert.ToInt16(wmiObject["TagId"])
                        };
                        deviceList.Add(newDevice);
                        counter++;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error in device list \n\n" + e);
                }
                return deviceList;
            }
        }
    }
