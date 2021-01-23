    public class SampleSentenceComparer : IEqualityComparer<SampleSentence> {
        public bool Equals(SampleSentence x, SampleSentence y) {
            if (x == y) return true;
            if (x == null || y == null) return false;
            return x.Text.Equals(y.Text);
        }
        public int GetHashCode(SampleSentence obj) {
            return obj.Text.GetHashCode();
        }
    }
