    internal class TransferRequestHandler : IHttpHandler {        
        public void ProcessRequest(HttpContext context) {
            IIS7WorkerRequest wr = context.WorkerRequest as IIS7WorkerRequest;
            if (wr == null) {
                throw new PlatformNotSupportedException(SR.GetString(SR.Requires_Iis_Integrated_Mode));
            }            
            wr.ScheduleExecuteUrl(null,
                                  null,
                                  null,
                                  true,
                                  context.Request.EntityBody,
                                  null,
                                  preserveUser: false);            
            context.ApplicationInstance.EnsureReleaseState();
            context.ApplicationInstance.CompleteRequest();
        }
        public bool IsReusable {
            get {
                return true;
            }
        }}
