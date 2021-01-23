    private void InitializeEVR(IBaseFilter pEVR, int dwStreams, out MediaFoundation.EVR.IMFVideoDisplayControl ppDisplay)
            {
                MediaFoundation.EVR.IMFVideoRenderer pRenderer;
                MediaFoundation.EVR.IMFVideoDisplayControl pDisplay;
                MediaFoundation.EVR.IEVRFilterConfig pConfig;
                MediaFoundation.EVR.IMFVideoPresenter pPresenter;
    
                // Before doing anything else, set any custom presenter or mixer.
    
                // Presenter?
                if (m_PresenterCLSID != Guid.Empty)
                {
                    Type type = Type.GetTypeFromCLSID(m_PresenterCLSID);
    
                    // An error here means that the custom presenter sample from
                    // http://mfnet.sourceforge.net hasn't been installed or
                    // registered.
                    pPresenter = (MediaFoundation.EVR.IMFVideoPresenter)Activator.CreateInstance(type);
    
                    try
                    {
                        pRenderer = (MediaFoundation.EVR.IMFVideoRenderer)pEVR;
    
                        pRenderer.InitializeRenderer(null, pPresenter);
                    }
                    finally
                    {
                        //Marshal.ReleaseComObject(pPresenter);
                    }
                }
    
                // Continue with the rest of the set-up.
    
                // Set the video window.
                object o;
                MediaFoundation.IMFGetService pGetService = null;
                pGetService = (MediaFoundation.IMFGetService)pEVR;
                pGetService.GetService(MediaFoundation.MFServices.MR_VIDEO_RENDER_SERVICE, typeof(MediaFoundation.EVR.IMFVideoDisplayControl).GUID, out o);
    
                try
                {
                    pDisplay = (MediaFoundation.EVR.IMFVideoDisplayControl)o;
                }
                catch
                {
                    Marshal.ReleaseComObject(o);
                    throw;
                }
    
                try
                {
                    // Set the number of streams.
                    pDisplay.SetVideoWindow(this.Handle);
    
                    if (dwStreams > 1)
                    {
                        pConfig = (MediaFoundation.EVR.IEVRFilterConfig)pEVR;
                        pConfig.SetNumberOfStreams(dwStreams);
                    }
    
                    // Set the display position to the entire window.
                    Rectangle r = this.ClientRectangle;
                    MediaFoundation.Misc.MFRect rc = new MediaFoundation.Misc.MFRect(r.Left, r.Top, r.Right, r.Bottom);
    
                    pDisplay.SetVideoPosition(null, rc);
    
                    // Return the IMFVideoDisplayControl pointer to the caller.
                    ppDisplay = pDisplay;
                }
                finally
                {
                    //Marshal.ReleaseComObject(pDisplay);
                }
                m_pMixer = null;
            }
