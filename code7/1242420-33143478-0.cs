    using System;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace Tests
    {
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var form = new Form();
    			var richTextBox = new RichTextBox { Dock = DockStyle.Fill, Parent = form };
    			var button = new Button { Dock = DockStyle.Bottom, Parent = form, Text = "Test" };
    			button.Click += (sender, e) =>
    			{
    				Color TextColor = Color.Black, OKColor = Color.Green, FailedColor = Color.Red;
    				var questions = Enumerable.Range(1, 20).Select(n => "Question #" + n).ToArray();
    				var random = new Random();
    				richTextBox.Clear();
    				for (int i = 0; i < questions.Length; i++)
    				{
    					richTextBox.SelectionColor = TextColor;
    					richTextBox.AppendText(questions[i] + ":");
    					bool ok = (random.Next() & 1) != 0;
    					var answer = (random.Next() & 1) != 0 ? "OK" : "Failed";
    					richTextBox.SelectionColor = ok ? OKColor : FailedColor;
    					richTextBox.AppendText(ok ? "OK" : "Failed");
    					richTextBox.SelectionColor = TextColor;
    					richTextBox.AppendText("\r\n");
    				}
    			};
    			Application.Run(form);
    		}
    	}
    }
