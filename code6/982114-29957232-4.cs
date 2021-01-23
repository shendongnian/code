    public interface IOrientation
        {
            AppOrientation CurrentOrientation { get; }
            IObservable<AppOrientation> Orientation { get; }
        }
    
        public enum AppOrientation
        {
            Unknown = 0,
            Portrait,
            Landscape
        }
