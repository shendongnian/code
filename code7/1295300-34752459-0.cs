    public BackgroundClass
    {
        public BackgroundClass(IInteractionService interactionService)
        {
            _interactionService = interactionService;
        }
    
        private readonly IInteractionService _interactionService;
    
        public static void ShowErrorReport(Exception e, SqlCommand sqlc = null)
        {
            try
            {
                _interactionService.ShowErrorReportDialog(e, sqlc);
            }
            catch (Exception f)
            {
                Debug.Print(f.ToString());
            }
        }
    }
    
    public interface IInteractionService
    {
        void ShowErrorReportDialog(Exception e, SqlCommand cmd);
    }
    
    public class WinFormsInteractionService : IInteractionService
    {
        public WinFormsInteractionService()
            this(SynchronizationContext.Current)
        {
        }
    
        public WinFormsInteractionService(SynchronizationContext syncContext)
        {
            if(syncContext == null)
                throw new ArgumentNullException("syncContext");
            _syncContext = syncContext;
        }
    
        private readonly SynchronizationContext _syncContext;
    
        public void ShowErrorReportDialog(Exception e, SqlCommand cmd)
        {
            _syncContext.Send(s => 
            {
                using(frmErrorReport frmER = new frmErrorReport(e, SqlCommand_: cmd))
                {
                    frmER.ShowDialog();
                }
            });
        }
    }
