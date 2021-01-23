	class Program {
		static Form1 frm;
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			frm = new Form1();
			frm.Test += TestEventHandler;
			new Thread(new ThreadStart(DoAsyncProcessing)).Start();
			Application.Run(frm);
		}
		static void DoAsyncProcessing() {
			// async code goes here
			Thread.Sleep(5000);
			// raise the event
			frm.RaiseTestEvent("Test Event Data");
		}
		static void TestEventHandler(object sender, TestEventArgs e) {
			System.Diagnostics.Debug.WriteLine("Received test event with data: " 
				+ e.EventData);
		}
	}
	public partial class Form1 : Form {
		public event EventHandler<TestEventArgs> Test;
		public Form1() {
			InitializeComponent();
		}
		public void RaiseTestEvent(string eventData) {
			var arg = new TestEventArgs() { EventData = eventData };
			OnTest(arg);
		}
		protected virtual void OnTest(TestEventArgs e) {
			EventHandler<TestEventArgs> handler = Test;
			if (handler != null)
				handler(this, e);
		}
	}
	public class TestEventArgs : EventArgs {
		public object EventData { get; set; }
	}
