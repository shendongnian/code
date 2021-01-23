    public class HardwareConsumer2
    {
        ICamera _camera;
        public HardwareConsumer2(ICamera camera)
        {
            _camera = camera;
        }
        public async void TakePhoto()
        {
            var result = await _camera.TakePhoto;
        }
    }
