    /// <summary> Interface frame event </summary>
    public delegate void HeFrame(System.Drawing.Bitmap BM);
    /// <summary> Frame event </summary>
    public event HeFrame FrameEvent2;
    private    byte[] savedArray;
    private    int    bufferedSize;
    
    int ISampleGrabberCB.BufferCB(double SampleTime, IntPtr pBuffer,
        int BufferLen )
    {
        this.bufferedSize = BufferLen;
    
        int stride = this.SnapShotWidth * 3;
    
        Marshal.Copy( pBuffer, this.savedArray, 0, BufferLen );
    
        GCHandle handle = GCHandle.Alloc( this.savedArray, GCHandleType.Pinned );
        int scan0 = (int) handle.AddrOfPinnedObject();
        scan0 += (this.SnapShotHeight - 1) * stride;
        Bitmap b = new Bitmap(this.SnapShotWidth, this.SnapShotHeight, -stride,
            System.Drawing.Imaging.PixelFormat.Format24bppRgb, (IntPtr) scan0 );
        handle.Free();
        SetBitmap=b;
        return 0;
    }
    /// <summary> capture event, triggered by buffer callback. </summary>
    private void OnCaptureDone()
    {
        Trace.WriteLine( "!!DLG: OnCaptureDone" );
    }
    /// <summary> Allocate memory space and set SetCallBack </summary>
    public void GrapImg()
    {
        Trace.Write ("IMG");
        if( this.savedArray == null )
        {
            int size = this.snapShotImageSize;
            if( (size < 1000) || (size > 16000000) )
                return;
            this.savedArray = new byte[ size + 64000 ];
        }
        sampGrabber.SetCallback( this, 1 );
    }
    /// <summary> Transfer bitmap upon firing event </summary>
    public System.Drawing.Bitmap SetBitmap
    {
        set
        {
            this.FrameEvent2(value);
        }
    }
