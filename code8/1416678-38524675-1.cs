    // hold the camera images.
    public class CameraImage
    {
        public bool Updated {get; set; }
        public BitmapSource Image {get; set; }
    }
    // cache
    private Dictionary<int, CameraImage> _cameraCache = new Dictionary<int, CameraImage>();
    
    // thread method to get the images.
    while (isDisplayThreadRunning)
    {
        for (int i = 0; i < numOfCamera; i++)
        {
            BitmapSource img = bitmapQueue[i].Serve(); //Pop the frame from Queue
            lock(_cameraCache)
            {
                CameraImage currentCameraImage;
                if(!_cameraCache.TryGetValue(i, out currentCameraImage))
                {
                    _cameraCache.Add(i, currentCameraImage = new CameraImage());
                }
                currentCameraImage.Image = img;
                currentCameraImage.Updated = true;
            }
        }
    }
    // index cycler
    private int _index;
    // display timer.
    public void DispatcherTimeMethod()
    {
        lock(_cameraCache)
        {
            CameraImage currentCameraImage;
            if(_cameraCache.TryGetValue(_index, out currentCameraImage))
                if(currentCameraImage.Updated)
                {
                    ControlDisplay[_index].DrawImage(currentCameraImage.Image);
                    currentCameraImage.Updated = false;
                }
        }
        _index++;
        if(_index >= MAXCAMERAS)
            _index = 0;
    }
