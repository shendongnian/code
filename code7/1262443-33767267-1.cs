    namespace UpdateUploader.ViewModels
    {
    using System.Windows.Input;
    using Helper;
    using Services;
    using System.Collections;
    using System.Collections.ObjectModel;
    using Google.Apis.Drive.v2.Data;
    using Google.Apis.Drive.v2;
    using System.Collections.Generic;
    public class MainWindowViewModel : ViewModelBase
    {
        DriveService _service;
        public MainWindowViewModel()
        {
            _service = DriveHelper.createDriveService("client_secret.json", false);
            googleDriveFolders = new NotifyTaskCompletion<List<File>>( DriveHelper.getFiles(_service, "trashed=false and mimeType = 'application/vnd.google-apps.folder'"));
        }
        public NotifyTaskCompletion<List<File>> _googleDriveFolders;
        public NotifyTaskCompletion<List<File>> googleDriveFolders
        {
            get { return _googleDriveFolders; }
            set
            {
                _googleDriveFolders = value;
                RaisePropertyChanged();
            }
        }
        #region ICommands
        private ICommand _refreshFoldersCommand;
        public ICommand refreshFoldersCommand
        {
            get
            {
                if (this._refreshFoldersCommand == null)
                {
                    _refreshFoldersCommand = new RelayCommand(p => this.loadFolders(p));
                }
                return this._refreshFoldersCommand;
            }
        }
        #endregion ICommands
        public void loadFolders(object parameter)
        {
            googleDriveFolders = new NotifyTaskCompletion<List<File>>(DriveHelper.getFiles(_service, "trashed=false and mimeType = 'application/vnd.google-apps.folder'"));
        }
    }
    }
