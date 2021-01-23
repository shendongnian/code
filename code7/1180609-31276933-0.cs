    public class Mod_Color
    {
        private Color color;
        public Mod_Color(float r, float g, float b)
        {
            this.color = Mod_Color(r, g, b, 255f);
        }
        public Mod_Color(float r, float g, float b, float a)
        {
            this.color = new Color(r / 255f, g / 255f, b / 255f, a / 255f);
        }
        public Color Get()
        {
            return this.color;
        }
    }
