    class Camera{
        private readonly IsTriggerLockCamera _locker;
        public Camera(IsTriggerLockCamera locker){
           if (locker== null)
           {
               throw new ArgumentNullException("locker");
           }
           _locker = locker;
        }
        public whatevermethod(){
            if (_locker.CameraLock){
               ...
            } 
        }
    }
