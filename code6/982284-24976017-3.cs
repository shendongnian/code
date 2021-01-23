	using System;
	using System.Threading;
	using System.Windows.Forms;
	class MyForm : Form {
		public static void Main() {
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MyForm());
		}
		TreeView tree = new TreeView() { Dock = DockStyle.Fill };
		MyForm() {
			Controls.Add(tree);
			tree.Nodes.Add("Loading...");
		}
		protected override void OnLoad(EventArgs e) {
			new Thread(Fill).Start();
			base.OnLoad(e);
		}
		void Create(string text) {
			if (InvokeRequired) Invoke(new Action<string>(this.Create), text);
			else tree.Nodes[0].Nodes.Add(text);
		}
		void Finish() {
			if (InvokeRequired) Invoke(new Action(this.Finish));
			else {
				tree.Nodes[0].Text = "The Nodes";
				tree.ExpandAll();
			}
		}
		void Fill() {
			for (int i = 0; i < 10; i++) {
				Create("Node #" + i.ToString());
				Thread.Sleep(100);
			}
			Finish();
		}
	}
