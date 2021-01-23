    class FrameGrabber : ISampleGrabberCB
    {
        IMediaControl mediaCtrl;
        int width, height, stride;
        public FrameGrabber(DsDevice camDevice)
        {
            IFilterGraph2 filterGraph;
            ICaptureGraphBuilder2 graphBuilder;
            IBaseFilter camBase, nullRenderer;
            ISampleGrabber sampleGrabber;
            filterGraph = new FilterGraph() as IFilterGraph2;
            mediaCtrl = filterGraph as IMediaControl;
            graphBuilder = new CaptureGraphBuilder2() as ICaptureGraphBuilder2;
            HRCheck(graphBuilder.SetFiltergraph(filterGraph));
            // Add camera
            HRCheck(filterGraph.AddSourceFilterForMoniker(
                camDevice.Mon, null, camDevice.Name, out camBase));
            // Add sample grabber
            sampleGrabber = new SampleGrabber() as ISampleGrabber;
            var mType = new AMMediaType()
            {
                majorType = MediaType.Video,
                subType = MediaSubType.RGB24,
                formatType = FormatType.VideoInfo
            };
            HRCheck(sampleGrabber.SetMediaType(mType));
            DsUtils.FreeAMMediaType(mType);
            HRCheck(sampleGrabber.SetCallback(this, 1));
            HRCheck(filterGraph.AddFilter(sampleGrabber as IBaseFilter, "CamGrabber"));
            // Add null renderer
            nullRenderer = new NullRenderer() as IBaseFilter;
            HRCheck(filterGraph.AddFilter(nullRenderer, "Null renderer"));
            // Render the webcam through the grabber and the renderer
            HRCheck(graphBuilder.RenderStream(PinCategory.Capture, MediaType.Video,
                camBase, sampleGrabber as IBaseFilter, nullRenderer));
            // Get resulting picture size
            mType = new AMMediaType();
            HRCheck(sampleGrabber.GetConnectedMediaType(mType));
            if (mType.formatType != FormatType.VideoInfo || mType.formatPtr == IntPtr.Zero)
            {
                throw new NotSupportedException("Unknown grabber media format");
            }
            var videoInfoHeader = Marshal.PtrToStructure(mType.formatPtr,
                typeof(VideoInfoHeader)) as VideoInfoHeader;
            width = videoInfoHeader.BmiHeader.Width;
            height = videoInfoHeader.BmiHeader.Height;
            Console.WriteLine("{0} x {1}", width, height); 
            stride = width * (videoInfoHeader.BmiHeader.BitCount / 8);
            DsUtils.FreeAMMediaType(mType);
            HRCheck(mediaCtrl.Run());
        }
        public int BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
        {
            Console.WriteLine("BufferCB: " + SampleTime.ToString());
            // This is the bitmap of the frame but you may want
            // to copy it to some other memory location to
            // process/save/send it from there
            var bmp = new Bitmap(width, height, stride,
                    PixelFormat.Format24bppRgb, pBuffer);
            return 0;
        }
        public int SampleCB(double SampleTime, IMediaSample pSample)
        {
            // This won't be called because sampleGrabber.SetCallback(this, 1)
            // -- 1 means BufferCB
            return Marshal.ReleaseComObject(pSample);
        }
        static void HRCheck(int hr)
        {
            DsError.ThrowExceptionForHR(hr);
        }
