	public abstract class WebViewPage :
		System.Web.Mvc.WebViewPage {
		public Employee UserPrincipal { get; set; }
		protected override void InitializePage() {
			base.InitializePage();
			Controller controller = (this.ViewContext.Controller as Controller);
			if (controller != null) {
				this.UserPrincipal = controller.UserPrincipal;
			}
		}
	}
