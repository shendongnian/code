    public void JustCallEventByUser<TEventArgs>(Action<object, TEventArgs> method, object sender, TEventArgs e) where TEventArgs : EventArgs
    {
        var frames = new System.Diagnostics.StackTrace().GetFrames();
    
        if (frames == null) return;
    
        //
        // This method (frames[0]= 'JustCallEventByUser') and declaration listener method (frames[1]= '(s, e)=>') must be removed from stack frames
        if (!frames.Skip(2).Any(x =>
        {
            Type declaringType = x.GetMethod().DeclaringType;
            return declaringType != null && declaringType.Name == this.Name;
        }))
        {  method.Invoke(sender, e); }
    }
