    public class Button { } 
    public static class ButtonExtensions 
    {
        public static int GetArea(this Button button)
        {
            return button.Width * button.Height;
        }
    }
