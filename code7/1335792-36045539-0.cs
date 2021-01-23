    public abstract class CustomWebViewPage : WebViewPage {
      public Glosrob Glosrob { get; set; }
      public override void InitHelpers() {
        base.InitHelpers();
        Glosrob = new Glosrob ();
      }
    }
