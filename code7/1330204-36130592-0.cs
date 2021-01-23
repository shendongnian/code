	using System;
	using System.Runtime.InteropServices;
	using System.Windows.Forms;
	using Visio = Microsoft.Office.Interop.Visio;
	namespace VisioInteropTest
	{
		[ComVisible(true)]
		public partial class TestForm : Form, Visio.IVisEventProc
		{
			Visio.Application app;
			bool initialised = false;
			// all AddAdvise events:
			// https://msdn.microsoft.com/en-us/library/office/ff768620.aspx
			const short appCloseEventCode = (short)(Visio.VisEventCodes.visEvtApp | Visio.VisEventCodes.visEvtBeforeQuit);
			const short docCloseEventCode = (short)(Visio.VisEventCodes.visEvtDoc | Visio.VisEventCodes.visEvtDel);
			public TestForm()
			{
				InitializeComponent();
			}
			private void visioButton_Click(object sender, EventArgs e)
			{
				if (init())
				{
					app.Documents.Add("");
				}
			}
			bool init()
			{
				if (!initialised)
				{
					app = new Visio.Application();
					app.EventList.AddAdvise(appCloseEventCode, this, null, null);
					app.EventList.AddAdvise(docCloseEventCode, this, null, null);
					initialised = true;
				}
				return initialised;
			}
			object Visio.IVisEventProc.VisEventProc(short eventCode, object source, int eventID, int eventSeqNum, object subject, object moreInfo)
			{
				switch (eventCode)
				{
					case appCloseEventCode: app_BeforeAppClose((Visio.Application)subject); break;
					case docCloseEventCode: app_BeforeDocumentClose((Visio.Document)subject); break;
				}
				return null;
			}
			void app_BeforeAppClose(Visio.Application app)
			{
				initialised = false;
				MessageBox.Show("App closed");
			}
			void app_BeforeDocumentClose(Visio.Document doc)
			{
				MessageBox.Show("Doc closed");
			}
		}
	}
