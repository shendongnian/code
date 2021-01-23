	public partial class _Default : Page 
	{
			public class Label : System.Web.UI.WebControls.Label {
			public string For = null;
			public override void RenderBeginTag(HtmlTextWriter writer) {
				AddAttributeIfExists(writer, "ID", ID);
				AddAttributeIfExists(writer, "For", For);
				writer.RenderBeginTag("Label");
			}
			private void AddAttributeIfExists(HtmlTextWriter writer, string name, string value) {
				if (!string.IsNullOrWhiteSpace(value))
					writer.AddAttribute(name, value);
			}
		}
		protected void Page_Load(object sender, EventArgs e) {
			StringWriter stringWriter = new StringWriter();
			HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
			Panel test = new Panel() { ID = "PanelTest" };
			TextBox txtCertificate = new TextBox() { ID = "txtCertificate" };
			Label lblCertificate = new Label() { ID = "lblCertificate", Text = "Certificate", For = txtCertificate.ClientID };
			test.Controls.Add(lblCertificate);
			test.Controls.Add(txtCertificate);
			test.RenderControl(writer);
			string teststring = writer.InnerWriter.ToString();
		}
	}
