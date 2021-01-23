    using System;
    using System.Collections.Generic;
    using System.ServiceProcess;
    using System.Reflection;
    using System.Configuration.Install;
    
    namespace MyWindowsService
    {
        [System.ComponentModel.RunInstallerAttribute(true)]
        public class MyServiceInstaller : Installer
        {
            ServiceInstaller _serviceInstaller = new ServiceInstaller();
            ServiceProcessInstaller _processInstaller = new ServiceProcessInstaller();
            string _serviceName = "MyWindowsService";
            string _displayName = "MyWindowsService";
            string _description = "My Windows Service Application";
    
            public MyServiceInstaller()
            {
    			this.BeforeInstall += new InstallEventHandler(ProjectInstaller_BeforeInstall);
    
    			_processInstaller.Account = ServiceAccount.LocalSystem;
    
    			_serviceInstaller.StartType = ServiceStartMode.Automatic;
    			_serviceInstaller.Description = _description;
    			_serviceInstaller.ServiceName = _serviceName;
    			_serviceInstaller.DisplayName = _displayName;
    
    			Installers.Add(_serviceInstaller);
    			Installers.Add(_processInstaller);
            }
    
            /// <summary>
            /// This function is called after installation completed
            /// </summary>
            /// <param name="savedState"></param>
            protected override void OnCommitted(System.Collections.IDictionary savedState)
            {
                ServiceController sc = new ServiceController(_serviceName);
    
                // Run Windows service if it is not running
                if (sc.Status != ServiceControllerStatus.Running)
                {
                    sc.Start();
                }
                else
                {
                    // Restart windows service if it is already running
                    RestartService(10000);
                }
            }
    
            private void RestartService(int timeoutMiliseconds)
            {
                ServiceController service = new ServiceController(_serviceName);
    
    			int millisec1 = Environment.TickCount;
    			TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMiliseconds);
    
    			service.Stop();
    			service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
    
    			int millisec2 = Environment.TickCount;
    			timeout = TimeSpan.FromMilliseconds(timeoutMiliseconds - (millisec2 - millisec1));
    			
    			service.Start();
    			service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
    
            void ProjectInstaller_BeforeInstall(object sender, System.Configuration.Install.InstallEventArgs e)
            {
    			List<ServiceController> services = new List<ServiceController>(ServiceController.GetServices());
    
    			foreach (ServiceController s in services)
    			{
    				if (s.ServiceName == this._serviceInstaller.ServiceName)
    				{
    					ServiceInstaller ServiceInstallerObj = new ServiceInstaller();
    					ServiceInstallerObj.Context = new System.Configuration.Install.InstallContext();
    					ServiceInstallerObj.Context = Context;
    					ServiceInstallerObj.ServiceName = _serviceName;
    					ServiceInstallerObj.Uninstall(null);
    				}
    			}
            }
        }
    }
