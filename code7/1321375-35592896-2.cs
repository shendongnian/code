	using System;
	using System.Threading;
	using System.Threading.Tasks;
	namespace WebApplication1
	{
		public partial class WebForm1 : System.Web.UI.Page
		{
			private static string _itemTemplate = "<table><tr><td>{0}</td></tr></table>";
			private static string _newHtml = string.Empty;
			private static bool _isWorking;
			protected void Page_Load(object sender, EventArgs e)
			{
			}
			protected void btnUpload_OnClick(object sender, EventArgs e)
			{
				Timer1.Enabled = _isWorking = true;
				Task.Factory.StartNew(() =>
				{
					for (var i = 0; i < 10; i++)
					{
						_newHtml = string.Format(_itemTemplate, i);
						//Simulate processing time
						Thread.Sleep(1000);
					}
				})
				.ContinueWith((prevTask) =>
				{
					_isWorking = false;
				});
			}
			protected void Timer1_OnTick(object sender, EventArgs e)
			{
				if (!_isWorking)
				{
					Timer1.Enabled = false;
					fileProgressDiv.InnerHtml = fileProgressDiv.InnerHtml + string.Format(_itemTemplate, "Process Finished!");
					return;
				}
				fileProgressDiv.InnerHtml = fileProgressDiv.InnerHtml + _newHtml;
				_newHtml = string.Empty;
			}
		}
	}
