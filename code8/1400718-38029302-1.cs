    public class TestDrawTexture : MonoBehaviour
    {
        DrawPixelTexture gray;
        DrawPixelTexture blue;
        bool firstRun;
    
        // Use this for initialization
        void OnGUI()
        {
            if (firstRun)
            {
                gray = new DrawPixelTexture();
                blue = new DrawPixelTexture();
                firstRun = false;
            }
    
            gray.txture(new Rect(0, 0, 100, 20), Color.gray);
    
            blue.txture(new Rect(0, 0, 100, 20), Color.blue);
    
        }
    }
