    public class MyCameraProcessor : IDisposable
    {
        // the thread for the processing.
        private Thread _processingThread;
        // a signal to check if the workerthread is busy with an image
        private ManualResetEvent _workerThreadIsBusy = new ManualResetEvent(false);
        // request for terminating
        private ManualResetEvent _terminating = new ManualResetEvent(false);
        // confirm terminated
        private ManualResetEvent _terminated = new ManualResetEvent(false);
        // store the current image.
        private Image _myImage;
        // event callback for new images
        private void Camera_FrameReady(object Sender, ImageEvent e)
        {
            // is the workerthread already processing an image? return.. (skip this image)
            if (_workerThreadIsBusy.WaitOne(0))
                return; // skip frame.
            //create a 'global' ref so the workerthread can access it.
            _myImage = e.Image;
            // signal the workerthread, so it starts processing the current image.
            _workerThreadIsBusy.Set();
        }
        private void ImageProcessingThread()
        {
            var waitHandles = new WaitHandle[] { _terminating, _workerThreadIsBusy };
            var run = true;
            while (run)
            {
                switch (EventWaitHandle.WaitAny(waitHandles))
                {
                    case 0:
                        // terminating.
                        run = false;
                        break;
                    case 1:
                        // process _myImage
                        ProcessImage(_myImage);
                        _workerThreadIsBusy.Reset();
                        break;
                }
            }
            _terminated.Set();
        }
        private void ProcessImage(Image _myImage)
        {
            // whatever...
        }
        // constructor
        public MyCameraProcessor()
        {
            // define the thread.
            _processingThread = new Thread(ImageProcessingThread);
            _processingThread.Start();
        }
        public void Dispose()
        {
            _terminating.Set();
            _terminated.WaitOne();
        }
    }
