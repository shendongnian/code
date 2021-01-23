using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
namespace Project2Service
{
    public partial class Service1 : ServiceBase
    {
        public enum ServiceCustomCommands { Command1 = 128, Command2 = 129 };
        //private IsolatedStorageScope iso;
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            WriteServiceInfo("Service Started!");
        }
        // This event is raised when a file is changed
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            WriteServiceInfo("File Changed!");
        }
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            WriteServiceInfo("File Created!");
        }
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            WriteServiceInfo("File Deleted!");
        }
        private void Watcher_Renamed(object sender, FileSystemEventArgs e)
        {
            WriteServiceInfo("File Renamed!");
        }
        private void WriteServiceInfo(string info)
        {
            FileStream fs = new FileStream(@"C:\Users\Adam\Desktop\WindowsServiceLog.txt",
                                 FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine(info + "\n");
            m_streamWriter.Flush();
            m_streamWriter.Close();
        }
        protected override void OnStop()
        {
            WriteServiceInfo("Service Stopped!");
        }
        protected override void OnCustomCommand(int command)
        {
            WriteServiceInfo("Command received");
            switch ((ServiceCustomCommands)command)
            {
                case ServiceCustomCommands.Command1:
                    //Command1 Implementation
                    IsolatedStorageFile isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null);
                    IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("LaptopInfo.txt", FileMode.Append, FileAccess.Write, isoFile);
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.WriteLine("Data");
                    }
                    //iso = IsolatedStorageScope.User;
                    break;
                case ServiceCustomCommands.Command2:
                    //iso = IsolatedStorageScope.User | IsolatedStorageScope.Assembly;
                    break;
                default:
                    break;
            }
        }
    }
}
