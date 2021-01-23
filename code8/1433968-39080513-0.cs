    //custom code before calling base.WndProc
    base.WndProc(ref m);
    //custom after base.WndProc returns
    WmScroll(); //VERY INEFFICIENT, called for each message :(
    }
    </pre>
    - Define WmScroll() as follows:
    <pre>
    protected virtual void WmScroll()
    {
    NativeMethods.ShowScrollBar(Handle, SB_BOTH, true);
    &#09;
    //si.fMask = SIF_PAGE | SIF_RANGE &lt;- initialized in .ctor
    &#09;
    NativeMethods.GetScrollInfo(Handle, SB_HORZ, ref si);
    if(si.nMax &lt; si.nPage)
    &#09;NativeMethods.EnableScrollBar(Handle, SB_HORZ, ESB_DISABLE_BOTH);
    else
    &#09;NativeMethods.EnableScrollBar(Handle, SB_HORZ, ESB_ENABLE_BOTH);
    NativeMethods.GetScrollInfo(Handle, SB_VERT, ref si);
    if(si.nMax &lt; si.nPage)
    &#09;NativeMethods.EnableScrollBar(Handle, SB_VERT, ESB_DISABLE_BOTH);
    else
    &#09;NativeMethods.EnableScrollBar(Handle, SB_VERT, ESB_ENABLE_BOTH);
    }
    </pre>
