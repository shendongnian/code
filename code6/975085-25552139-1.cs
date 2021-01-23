    public class MyLittlePony {
        public string Name { get; set; }
        public Int32 Argb {
            get {
                return Color.ToArgb();
            }
            set {
                Color = Color.FromArgb(value);
            }
        }
        [NotMapped]
        public Color Color { get; set; }
    }
