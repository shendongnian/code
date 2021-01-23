    var x = new GENERIC_FTP_SEND();
    //  Add it to your context immediately
    ctx.GENERIC_FTP_SEND.Add(x);
    //  Then something along these lines 
    foreach (Control cntrl in ControlList)
    {
        ctx.Entry(x).Property(cntrl.Name).CurrentValue = ctrl.Text;
    }
