    public class UIMessageEventArgs : EventArgs
    {
        public string Key { get; private set; }
        public Func<CultureInfo, string> GetString { get; private set; }
        public UIMessageEventArgs(string key, Func<CultureInfo, string> getString)
        {
            if (key == null || getString == null)
                throw new ArgumentNullException();
            this.Key = key;
            this.GetString = getString;
        }
    }
    public interface IUIMessageService
    {
        event EventHandler<UIMessageEventArgs> OnMessage;
        void ShowMessage(object sender, string key, Func<CultureInfo, string> getString);
    }
    public sealed class UIMessageService : IUIMessageService
    {
        static UIMessageService() { instance = new UIMessageService(); }
        static UIMessageService instance;
        public static UIMessageService Instance { get { return instance; } }
        UIMessageService() { }
        #region IUIMessageService Members
        public event EventHandler<UIMessageEventArgs> OnMessage;
        public void ShowMessage(object sender, string key, Func<CultureInfo, string> getString)
        {
            if (getString == null)
                throw new ArgumentNullException("getString");
            if (key == null)
                throw new ArgumentNullException("key");
            var onMessage = OnMessage;
            if (onMessage != null)
                onMessage(sender, new UIMessageEventArgs(key, getString));
        }
        #endregion
    }
    public static class UIMessageExtensions
    {
        public static void ShowMessage(this ResourceManager resourceManager, string key)
        {
            if (resourceManager == null)
                throw new ArgumentNullException("resourceManager");
            if (key == null)
                throw new ArgumentNullException("key");
            UIMessageService.Instance.ShowMessage(resourceManager, key, c => resourceManager.GetString(key, c));
        }
    }
