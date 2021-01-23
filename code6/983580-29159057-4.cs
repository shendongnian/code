    public enum MaskType
    {
        None = 1,
        Clear,
        Black,
        Gradient
    }
    
    public interface IHudService
    {
        void Show(string message, MaskType maskType, int progress = -1);
        void Dismiss();
        void ShowToast(string message, bool showToastCentered = true, double timeoutMs = 1000);
        void ShowToast(string message, MaskType maskType, bool showToastCentered = true, double timeoutMs = 1000);
    }
