    namespace Microsoft.Win32.TaskScheduler
    { 
        public class Task : IDisposable
        {
            public TaskDefinition Definition { get; }
            public bool Enabled { get; set; }
            public TaskFolder Folder { get; }
            public bool IsActive { get; }
            public DateTime LastRunTime { get; }
            public int LastTaskResult { get; }
            public string Name { get; }
            public DateTime NextRunTime { get; }
            public int NumberOfMissedRuns { get; }
            public string Path { get; }
            public bool ReadOnly { get; }
            public GenericSecurityDescriptor SecurityDescriptor { get; set; }
            public virtual TaskState State { get; }
            public TaskService TaskService { get; }
            public string Xml { get; }
            public void Dispose();
            public void Export(string outputFileName);
            public TaskSecurity GetAccessControl();
            public TaskSecurity GetAccessControl(AccessControlSections includeSections);
            public RunningTaskCollection GetInstances();
            public DateTime GetLastRegistrationTime();
            public DateTime[] GetRunTimes(DateTime start, DateTime end, uint count = 0);
            public string GetSecurityDescriptorSddlForm(SecurityInfos includeSections = SecurityInfos.Owner | SecurityInfos.Group | SecurityInfos.DiscretionaryAcl);
            public void RegisterChanges();
            public RunningTask Run(params string[] parameters);
            public RunningTask RunEx(TaskRunFlags flags, int sessionID, string user, params string[] parameters);
            public void SetAccessControl(TaskSecurity taskSecurity);
            public void SetSecurityDescriptorSddlForm(string sddlForm, TaskSetSecurityOptions options = TaskSetSecurityOptions.None);
            public void ShowPropertyPage();
            public void Stop();
            public override string ToString();
        }
    }    
