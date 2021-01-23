    public class GradientCustomBrush : CustomBrush
    {
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
        public override string ToString()
        {
            return "Gradient";
        }
    }
