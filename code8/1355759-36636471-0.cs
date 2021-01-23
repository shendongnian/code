    public bool IsPostBack {
        get {
            if (_requestValueCollection == null)
                return false;
     
            // Treat it as postback if the page is created thru cross page postback.
            if (_isCrossPagePostBack)
                return true;
     
            // Don't treat it as a postback if the page is posted from cross page
            if (_pageFlags[isCrossPagePostRequest])
                return false;
     
            // Don't treat it as a postback if a view state MAC check failed and we
            // simply ate the exception.
            if (ViewStateMacValidationErrorWasSuppressed)
                return false;
     
            // If we're in a Transfer/Execute, never treat as postback (ASURT 121000)
            // Unless we are being transfered back to the original page, in which case
            // it is ok to treat it as a postback (VSWhidbey 117747)
            // Note that Context.Handler could be null (VSWhidbey 159775)
            if (Context.ServerExecuteDepth > 0 &&
                (Context.Handler == null || GetType() != Context.Handler.GetType())) {
                return false;
            }
     
            // If the page control layout has changed, pretend that we are in
            // a non-postback situation.
            return !_fPageLayoutChanged;
        }
    }
