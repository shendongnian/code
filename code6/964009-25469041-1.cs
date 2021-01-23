    public class TimeoutFilter : ActionFilterAttribute
    {
        public int Timeout { get; set; }
        public TimeoutFilter( )
        {
            this.Timeout = int.MaxValue;
        }
        public TimeoutFilter( int timeout )
        {
            this.Timeout = timeout;
        }
       
        public override async Task OnActionExecutingAsync( HttpActionContext actionContext, CancellationToken cancellationToken )
        {
           
            var     controller     = actionContext.ControllerContext.Controller;
            var     controllerType = controller.GetType( );
            var     action         = controllerType.GetMethod( actionContext.ActionDescriptor.ActionName );
            var     tokenSource    = new CancellationTokenSource( );
            var     timeout        = this.TimeoutTask( this.Timeout );
            object result          = null;
            var work = Task.Run( ( ) =>
                                 {
                                     result = action.Invoke( controller, actionContext.ActionArguments.Values.ToArray( ) );
                                 }, tokenSource.Token );
            var finishedTask = await Task.WhenAny( timeout, work );
            if( finishedTask == timeout )
            {
                tokenSource.Cancel( );
                actionContext.Response = actionContext.Request.CreateResponse( HttpStatusCode.RequestTimeout );
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse( HttpStatusCode.OK, result );
            }
        }
        private async Task TimeoutTask( int timeoutValue )
        {
            await Task.Delay( timeoutValue );
        }
    }
