     [ServiceContract(CallbackContract = typeof(IDownloadManagerServiceCalback))] 
     public interface IDownloadManagerServiceCalback
     {
         /// <summary>
         /// Returns changed downloading status to client.
         /// </summary>
         /// <returns>Downloading which has changed status</returns>
         [OperationContract(IsOneWay = true)]
         void UpdateSelectedDownload(DownloadStatus p_SelectedDownload);
     }
