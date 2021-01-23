    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	static class Test
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var form = new Form();
    			var txtName = new TextBox { Parent = form, Top = 8, Left = 8 };
    			var buttonNext = new Button { Parent = form, Top = txtName.Bottom + 8, Left = 8, Text = "Next" };
    			form.Load += async (sender, e) =>
    			{
    				var List = new List<string> { "A", "B", "C", "D " };
    				foreach (string s in List)
    				{
    					txtName.Text = s;
    					await buttonNext.WhenClicked();
    				}
    				txtName.Text = "";
    				buttonNext.Enabled = false;
    			};
    			Application.Run(form);
    		}
    	}
    	public static class Utils
    	{
    		public static Task WhenClicked(this Button button)
    		{
    			var tcs = new TaskCompletionSource<object>();
    			EventHandler onClick = null;
    			onClick = (sender, e) =>
    			{
    				button.Click -= onClick;
    				tcs.TrySetResult(null);
    			};
    			button.Click += onClick;
    			return tcs.Task;
    		}
    	}
    }
