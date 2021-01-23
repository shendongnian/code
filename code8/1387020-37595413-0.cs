    public virtual int EndRead(IAsyncResult asyncResult)
    {
        if (asyncResult == null)
        {
            throw new ArgumentNullException("asyncResult");
        }
        if (this._readDelegate == null)
        {
            throw new ArgumentException(Environment.GetResourceString("InvalidOperation_WrongAsyncResultOrEndReadCalledMultiple"));
        }
        int num = -1;
        try
        {
            num = this._readDelegate.EndInvoke(asyncResult);
        }
        finally
        {
            this._readDelegate = null;
            this._asyncActiveEvent.Set();
            this._CloseAsyncActiveEvent(Interlocked.Decrement(ref this._asyncActiveCount));
        }
        return num;
    }
