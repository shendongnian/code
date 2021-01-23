    using System;
    using System.Collections.ObjectModel;
    using System.Management;
    using System.Windows;
    
    namespace Agent.cls
    {
        public class Hw
        {
            public int DeviceId;
            public bool AcceptPause;
            public bool AcceptStop;
            public string Caption;
            public string CreationClassName;
            public string Description;
            public bool DeskTopInteract;
            public string DisplayName;
            public string ErrorControl;
            public int ExitCode;
            public DateTime InstallDate;
            public string Name;
            public string PathName;
            public int ServiceSpecificExitCode;
            public string ServiceType;
            public bool started;
            public string StartMode;
            public string StartName;
            public string State;
            public string Status;
            public string SystemCreationClassName;
            public string SystemName;
            public int TagId;
    
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
