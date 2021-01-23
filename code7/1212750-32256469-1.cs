    public class ChartFeature : IFeature {
        public void Accept(IFeatureVisitor visitor) {
            visitor.Visit(this);
        }
    }
