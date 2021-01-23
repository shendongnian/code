    public class Consumer : IDisposable {    
        private ProducerProxy itsProducerProxy;
        // how we signal others that we are disposed
        private CancellationTokenSource _cts = new CancellationTokenSource();
        
        /*  SNIP  */
        
        public void OnNotificationEvent(object sender, EventArgs args) {
            // We now provide the inner process with the cancellation token
            DealWithNotification(_cts.Token); 
        }
        
        public void Dispose() 
        {
            // not thread safe but you get the gist
            if (_cts!= null) {
                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
            /*  SNIP  */
        }
    }
