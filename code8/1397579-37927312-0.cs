	public class Form : System.Web.UI.HtmlControls.HtmlForm
	{
		/// <summary>
		/// The RenderAttributes method adds the attributes to the rendered &lt;form&gt; tag.
		/// We override this method so that the action attribute is not emitted.
		/// </summary>
		protected override void RenderAttributes(HtmlTextWriter writer)
		{
            // You cannot simply remove the form action as it seems to get rendered anyway
			// but if you set it to the RawURL it will be the correct value on URL rewritten pages.
			base.Attributes["action"] = HttpContext.Current.Request.RawUrl;
			base.RenderAttributes(writer);
		}
	}
