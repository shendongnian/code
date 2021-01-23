    using System;
    using System.Collections.Generic; 
    using System.IO;
    using System.Linq; 
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Genesis.Windows.Desktop.Account
    {
        [Serializable]
        internal class UserSettings : ISerializable
        {
            // CaseSync
            public String AccountId { get; set; }
            public String Email { get; set; }
            internal String _password = "";
        public String Password 
        {
            get
            {
                return Security.ValueSecurity.DecryptString(_password, MainWindow.ApplicationId);
            }
            set
            {
                string password = value;
                if(!String.IsNullOrWhiteSpace(value))
                    password = Security.ValueSecurity.EncryptString(value, MainWindow.ApplicationId);
                _password = password;
            }
        }
        public bool RememberMe { get; set; }
        public Genesis.Portal.Controllers.API.AuthToken AuthenticationToken { get; set; }
        public String WebAPIUrl = "https://127.0.0.1/API/";
         
        // Outlook
        public bool IsOutlookSyncReady { get; set; }
        public List<String> OutlookAccounts { get; set; }
        public String OutlookCalendarFolderName { get; set; }
        public string OutlookCalendarFolderId { get; set; }
        public string OutlookProfileName { get; set; }
        
        // GMail
        public bool IsGMailSyncReady { get; set; }
        public String GMailToken { get; set; }
        public String GMailCalendarFolderName { get; set; }        
        // PIM Calendar Sync
        public DateTime LastCalendarSyncDate { get; set; }
        public int TotalCalendarRecords { get; set; }
        public int LastCalendarAddCount { get; set; }
        public int LastCalendarEditCount { get; set; }
        public int LastCalendarDeleteCount { get; set; }
        // PIM Tasks Sync
        public DateTime LastTasksSyncDate { get; set; }
        public int TotalTaskRecords { get; set; }
        public int LastTasksAddCount { get; set; }
        public int LastTasksEditCount { get; set; }
        public int LastTasksDeleteCount { get; set; }
        // PIM Email Sync
        public DateTime LastEmailSyncDate { get; set; }
        public int TotalEmailRecords { get; set; }
        public int LastEmailAddCount { get; set; }
        public int LastEmailEditCount { get; set; }
        public int LastEmailDeleteCount { get; set; }
        // PIM Contacts Sync
        public DateTime LastContactsSyncDate { get; set; }
        public int TotalContactsRecords { get; set; }
        public int LastContactsAddCount { get; set; }
        public int LastContactsEditCount { get; set; }
        public int LastContactsDeleteCount { get; set; }
        public UserSettings()
        {
            this.AccountId = "";
            this.Email = "";
            this.GMailCalendarFolderName = "My Case Folder";
            this.GMailToken = "";
            this.IsGMailSyncReady = false;
            this.IsOutlookSyncReady = false;
            this.OutlookAccounts = new List<String>();
            this.OutlookCalendarFolderName = "My Case Folder";
            this.OutlookCalendarFolderId = null;
            this.OutlookProfileName = ""; // Not Known
            this.Password = "";
            this.RememberMe = false;
            
            LastCalendarSyncDate = DateTime.Parse("1/1/1900"); // Using history will trigger a sync on first run.
            LastCalendarAddCount = 0;
            LastCalendarDeleteCount = 0;
            LastCalendarEditCount = 0;
            TotalCalendarRecords = 0;
            LastTasksSyncDate = DateTime.Parse("1/1/1900"); // Using history will trigger a sync on first run.
            LastTasksAddCount = 0;
            LastTasksEditCount = 0;
            LastTasksDeleteCount = 0;
            TotalTaskRecords = 0;
            LastEmailSyncDate = DateTime.Parse("1/1/1900"); // Using history will trigger a sync on first run.
            LastEmailAddCount = 0;
            LastEmailDeleteCount = 0;
            LastEmailEditCount = 0;
            TotalEmailRecords = 0;
            LastContactsSyncDate = DateTime.Parse("1/1/1900"); // Using history will trigger a sync on first run.
            LastContactsAddCount = 0;
            LastContactsDeleteCount = 0;
            LastContactsEditCount = 0;
            TotalContactsRecords = 0;
            
        }
        public UserSettings(SerializationInfo info, StreamingContext context)
        {
            this.AccountId = info.GetString("AccountId");
            this.Email = info.GetString("Email");
            this.GMailCalendarFolderName = info.GetString("GMailCalendarFolderName");
            this.GMailToken = info.GetString("GMailToken");
            this.IsGMailSyncReady = info.GetBoolean("IsGMailSyncReady");
            this.IsOutlookSyncReady = info.GetBoolean("IsOutlookSyncReady");
            this.OutlookCalendarFolderName = info.GetString("OutlookCalendarFolderName");
            this._password = info.GetString("Password");
            this.RememberMe = info.GetBoolean("RememberMe");
            
            this.LastCalendarSyncDate = info.GetDateTime("LastCalendarSyncDate");  
            this.LastTasksSyncDate = info.GetDateTime("LastTasksSyncDate");  
            this.LastContactsSyncDate = info.GetDateTime("LastCalendarSyncDate");  
            this.LastEmailSyncDate = info.GetDateTime("LastEmailSyncDate");
            this.OutlookProfileName = info.GetString("OutlookProfileName"); 
            LastCalendarAddCount = info.GetInt32("LastCalendarAddCount");
            LastCalendarDeleteCount = info.GetInt32("LastCalendarDeleteCount");
            LastCalendarEditCount = info.GetInt32("LastCalendarEditCount");
            TotalCalendarRecords = info.GetInt32("TotalCalendarRecords");
            LastTasksAddCount = info.GetInt32("LastTasksAddCount");
            LastTasksEditCount = info.GetInt32("LastTasksEditCount");
            LastTasksDeleteCount = info.GetInt32("LastTasksDeleteCount");
            TotalTaskRecords = info.GetInt32("TotalTaskRecords");
            LastEmailAddCount = info.GetInt32("LastEmailAddCount");
            LastEmailDeleteCount = info.GetInt32("LastEmailDeleteCount");
            LastEmailEditCount = info.GetInt32("LastEmailEditCount");
            TotalEmailRecords = info.GetInt32("TotalEmailRecords");
            LastContactsAddCount = info.GetInt32("LastContactsAddCount");
            LastContactsDeleteCount = info.GetInt32("LastContactsDeleteCount");
            LastContactsEditCount = info.GetInt32("LastContactsEditCount");
            TotalContactsRecords = info.GetInt32("TotalContactsRecords");
            WebAPIUrl = info.GetString("WebAPIUrl");
            this.OutlookAccounts = new List<String>();
            int outlookAcountsCount = info.GetInt16("outlookAcountsCount");
            for (int i = 0; i < outlookAcountsCount; i++ )
                    this.OutlookAccounts.Add(info.GetString("OutlookAccount["+i.ToString()+"]"));
            try
            {
                this.OutlookCalendarFolderId = info.GetString("OutlookCalendarFolderId");
            }
            catch (Exception) {/*Not supported in all versions*/}
        
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LastCalendarSyncDate", this.LastCalendarSyncDate);
            info.AddValue("LastTasksSyncDate", this.LastTasksSyncDate);
            info.AddValue("LastContactsSyncDate", this.LastContactsSyncDate);
            info.AddValue("LastEmailSyncDate", this.LastEmailSyncDate);
            info.AddValue("AccountId",  this.AccountId);
            info.AddValue("Email", this.Email);
            info.AddValue("GMailCalendarFolderName", this.GMailCalendarFolderName);
            info.AddValue("GMailToken", this.GMailToken);
            info.AddValue("IsGMailSyncReady", this.IsGMailSyncReady);
            info.AddValue("IsOutlookSyncReady", this.IsOutlookSyncReady);
            info.AddValue("OutlookCalendarFolderName", this.OutlookCalendarFolderName);
            info.AddValue("Password", this._password);
            info.AddValue("RememberMe", this.RememberMe);
            info.AddValue("OutlookProfileName", this.OutlookProfileName); 
            
            info.AddValue("LastCalendarAddCount", LastCalendarAddCount);
            info.AddValue("LastCalendarDeleteCount", LastCalendarDeleteCount);
            info.AddValue("LastCalendarEditCount", LastCalendarEditCount);
            info.AddValue("TotalCalendarRecords", TotalCalendarRecords);
            info.AddValue("LastTasksAddCount", LastTasksAddCount);
            info.AddValue("LastTasksEditCount", LastTasksEditCount);
            info.AddValue("LastTasksDeleteCount", LastTasksDeleteCount);
            info.AddValue("TotalTaskRecords", TotalTaskRecords);
            info.AddValue("LastEmailAddCount", LastEmailAddCount);
            info.AddValue("LastEmailDeleteCount", LastEmailDeleteCount);
            info.AddValue("LastEmailEditCount",LastEmailEditCount);
            info.AddValue("TotalEmailRecords",TotalEmailRecords);
            info.AddValue("LastContactsAddCount",LastContactsAddCount);
            info.AddValue("LastContactsDeleteCount",LastContactsDeleteCount);
            info.AddValue("LastContactsEditCount",LastContactsEditCount);
            info.AddValue("TotalContactsRecords",TotalContactsRecords);
            info.AddValue("WebAPIUrl", WebAPIUrl);
            info.AddValue("outlookAcountsCount", this.OutlookAccounts.Count);
            int i = 0;
            foreach (String account in this.OutlookAccounts)
            {
                info.AddValue("OutlookAccount[" + i.ToString() + "]", account);
                i++;
            }
            try
            {
                if(this.OutlookCalendarFolderId != null)
                    info.AddValue("OutlookCalendarFolderId", this.OutlookCalendarFolderId);
            }
            catch (Exception) {/*Not supported in all versions*/}
        }
        internal static void Save(UserSettings file)
        {
            if (String.IsNullOrWhiteSpace(file.FilePath))
            {
                FolderBrowserDialog saveFolder = new System.Windows.Forms.FolderBrowserDialog();
                if (saveFolder.ShowDialog() == DialogResult.Cancel)
                    return;
                file.FilePath = System.IO.Path.Combine(saveFolder.SelectedPath, "User.settings");
            }
            FileStream fs = new FileStream(file.FilePath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, file);
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Failed to serialize. Reason: " + e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        internal static UserSettings Load(String filePath)
        {
            UserSettings file = null;
            if (!System.IO.File.Exists(filePath))
            {
                file = new UserSettings();
                file.FilePath = filePath;
                UserSettings.Save(file);
            }
            else
            {
                FileStream fs = new FileStream(filePath, FileMode.Open);
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    file = (UserSettings)formatter.Deserialize(fs);
                    file.FilePath = filePath;
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
            return file;
        }
        internal static void Clear(string file)
        {
            if (System.IO.File.Exists(file))
            {
                System.IO.File.Delete(file);
            }
        }
        public string FilePath { get; set; }
    }
}
