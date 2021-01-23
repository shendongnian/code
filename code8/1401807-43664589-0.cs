    /*
    At first you need to declare that your program will be using winRT libraries:
    1. Right click on your yourProject, select Unload Project
    2. Right click on your youProject(unavailable) and click Edit yourProject.csproj
    3. Add a new property group:<TargetPlatformVersion>8.0</TargetPlatformVersion>
    4. Reload project
    5. Add referece Windows from Windows > Core
    */
    using System;
    using Windows.Data.Xml.Dom;
    using Windows.Storage;
    using Windows.Storage.Streams;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Notifications;
    
    namespace ConsoleApplication6
    {
        public class NewToastNotification
        {
            public NewToastNotification(string input, int type)
            {
                string NotificationTextThing = input;
                string Toast = "";
                switch (type)
                {
                    case 1:
                        {
                            //Basic Toast
                            Toast = "<toast><visual><binding template=\"ToastImageAndText01\"><text id = \"1\" >";
                            Toast += NotificationTextThing;
                            Toast += "</text></binding></visual></toast>";
                            break;
                        }
                    default:
                        {
                            Toast = "<toast><visual><binding template=\"ToastImageAndText01\"><text id = \"1\" >";
                            Toast += "Default Text String";
                            Toast += "</text></binding></visual></toast>";
                            break;
                        }
                }
                XmlDocument tileXml = new XmlDocument();
                tileXml.LoadXml(Toast);
                var toast = new ToastNotification(tileXml);
                ToastNotificationManager.CreateToastNotifier("New Toast Thing").Show(toast);
            }
    }
    
        class Program
        {
            static void Main(string[] args)
            {
                NewToastNotification Window = new NewToastNotification("Yes",1);
    
                
            }
        }
    }
