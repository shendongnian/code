    public class ValueTweenItem : TweenItem {
        public string propertyName;
        public float startValue = 0f;
        public float endValue = 1f;
    }
    public class ColorTweenItem : TweenItem {
        public Gradient gradient;
    }
