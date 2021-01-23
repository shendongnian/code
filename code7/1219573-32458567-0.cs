    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace BlueMercs.Core.Services.WMI
    {
    
      public class EventUsbMonitorEvent : EventArgs
      {
        public string Model { get; set; }
        public string Drive { get; set; }
      }
    
      public class UsbMonitor
      {
        private const string _queryForEvents = @"SELECT * FROM __InstanceOperationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_DiskDrive'";
        private string _queryDiskPartitionDevice = "ASSOCIATORS OF {Win32_DiskDrive.DeviceID=\"{0}\"} WHERE AssocClass = Win32_DiskDriveToDiskPartition";
        private string _queryDiskLogicalPartition = "ASSOCIATORS OF {Win32_DiskPartition.DeviceID=\"{0}\"} WHERE AssocClass = Win32_LogicalDiskToPartition";
    
        
    
        private readonly ManagementEventWatcher _watcher;
        private Thread _thread;
    
        public UsbMonitor()
        {
          _watcher = new ManagementEventWatcher();
          var query = new WqlEventQuery(_queryForEvents);
          _watcher.EventArrived += Watcher_EventArrived;
          _watcher.Query = query;
        }
    
        public void Start()
        {
          _watcher.Start();
          _thread = new Thread(Listen);
          _thread.Start();
        }
    
        public void Stop()
        {
          try { _thread.Abort(); } catch { } //suppress thread abort exception
          _watcher.Stop();
        }
    
        private void Listen()
        {
          _watcher.WaitForNextEvent();
          Listen();
        }
    
        private string GetDriveLetterFromDisk(string name)
        {
          name = name.Replace(@"\", @"\\");
          var driveLetter = string.Empty;
          var qryPartition = new ObjectQuery("ASSOCIATORS OF {Win32_DiskDrive.DeviceID=\"" + name + "\"} WHERE AssocClass = Win32_DiskDriveToDiskPartition"); //string.Format(_queryDiskPartitionDevice, name));
          var partition = new ManagementObjectSearcher(qryPartition);
    
          foreach (var result in partition.Get())
          {
            //var qryLogicalDisk = new ObjectQuery(string.Format(_queryDiskLogicalPartition, result["DeviceID"]));
            var logicalDisk = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID=\"" + result["DeviceID"] + "\"} WHERE AssocClass = Win32_LogicalDiskToPartition"); //qryLogicalDisk);
            driveLetter = logicalDisk.Get().Cast<ManagementBaseObject>().Aggregate(driveLetter, (current, x) => current + (x["Name"] + ","));
          }
    
          return driveLetter.Trim(',');
        }
    
        private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
          ManagementBaseObject targetInstance;
    
          switch (e.NewEvent.ClassPath.ClassName)
          {
            case "__InstanceCreationEvent":
              targetInstance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
              if (targetInstance["InterfaceType"].ToString() == "USB")
              {
                var driveName = targetInstance["Caption"].ToString();
                var driveLetter = GetDriveLetterFromDisk(targetInstance["Name"].ToString());
                if (OnExternalUsbDetected != null)
                  OnExternalUsbDetected(this, new EventUsbMonitorEvent { Model = driveName, Drive = driveLetter });
              }
              break;
    
            case "__InstanceDeletionEvent":
              targetInstance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
              if (targetInstance["InterfaceType"].ToString() == "USB")
              {
                var driveName = targetInstance["Caption"].ToString();
                var driveLetter = GetDriveLetterFromDisk(targetInstance["Name"].ToString());
                if (OnExternalUsbRemoved != null)
                  OnExternalUsbRemoved(this, new EventUsbMonitorEvent { Model = driveName, Drive = driveLetter });
              }
              break;
          }
        }
    
        public event EventHandler<EventUsbMonitorEvent> OnExternalUsbDetected;
        public event EventHandler<EventUsbMonitorEvent> OnExternalUsbRemoved;
      }
    }
