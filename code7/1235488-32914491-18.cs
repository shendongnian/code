      using System;
        using System.Collections.Generic;
        using System.Diagnostics;
        using System.IO;
        using System.Management;
        using System.Windows;
        using System.Windows.Input;
        
        namespace TestPopWpfWindow
        {
            
            public class UsbDriveInfoDemoViewModel : ViewModelBase, IDisposable
            {
        
                public UsbDriveInfoDemoViewModel()
                {
                    DriveInfos = new List<DriveInfo>();
                    ReloadDriveInfos();
                    RegisterManagementEventWatching(); 
                    TargetUsbDrive = @"E:\"; 
                    AccessCommand = new RelayCommand(x => true, x => MessageBox.Show("Functionality executed."));
                }
        
                public int UsbDriveCount { get; set; }
        
                private string _targetUsbDrive;
        
                public string TargetUsbDrive
                {
                    get { return _targetUsbDrive; }
                    set
                    {
                        if (_targetUsbDrive != value)
                        {
                            _targetUsbDrive = value; 
                            RaisePropertyChanged("TargetUsbDrive");
                            RaisePropertyChanged("DriveInfo");
                        }
                    }
                }
        
                public ICommand AccessCommand { get; set; }
        
                private void ReloadDriveInfos()
                {
                    var usbDrives = UsbDriveListProvider.GetAllRemovableDrives();
        
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        DriveInfos.Clear();
        
                        foreach (var usbDrive in usbDrives)
                        {
                            DriveInfos.Add(usbDrive);
                        }
                        UsbDriveCount = DriveInfos.Count;
                        RaisePropertyChanged("UsbDriveCount");
                        RaisePropertyChanged("DriveInfos");
                    }); 
                }
        
                public List<DriveInfo> DriveInfos { get; set; }
        
                private ManagementEventWatcher _watcher;
        
                private void RegisterManagementEventWatching()
                {
                    _watcher = new ManagementEventWatcher();
                    var query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent");
                    _watcher.EventArrived += watcher_EventArrived;
                    _watcher.Query = query;
                    _watcher.Start();
                }
        
                private void watcher_EventArrived(object sender, EventArrivedEventArgs e)
                {
                    Debug.WriteLine(e.NewEvent);
                    ReloadDriveInfos();
                }
        
        
        
                public void Dispose()
                {
                    if (_watcher != null)
                    {
                        _watcher.Stop();
                        _watcher.EventArrived -= watcher_EventArrived;
                    }
                }
        
            }
        
        }
