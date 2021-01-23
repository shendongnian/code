    public class ValueTweenItem {
        public string propertyName;
        public float startValue = 0f;
        public float endValue = 1f;
    }
    public class ColorTweenItem : ValueTweenItem {
        public Gradient gradient;
    }
