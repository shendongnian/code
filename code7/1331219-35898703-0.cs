    public class Test {
      [Editor(typeof(TestEditor), typeof(UITypeEditor))]
      public List<SocialPolicy> Policies { get; }
      public Test() {
        this.Policies = new List<SocialPolicy>();
        this.Policies.Add(new SocialPolicy());
      }
      public class TestEditor : CollectionEditor {
        public TestEditor(Type type)
            : base(type) {
        }
        protected override string GetDisplayText(object value) {
          if (value is SocialPolicy) {
            return ((SocialPolicy)value).ID;
          } else {
            return value.ToString();
          }
        }
      }
    }
