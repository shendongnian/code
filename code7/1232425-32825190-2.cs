    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	public class NonSelectableButton : Button
    	{
    		public NonSelectableButton()
    		{
    			SetStyle(ControlStyles.Selectable, false);
    		}
    	}
    
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var form = new Form();
    			Control[] controls = { new TextBox(), new TextBox(), };
    			Button[] buttons = { new NonSelectableButton { Text = "Prev" }, new NonSelectableButton { Text = "Next" }, };
    			foreach (var button in buttons)
    				button.Click += (sender, e) => MessageBox.Show("Button " + ((Button)sender).Text + " clicked!");
    			int y = 0;
    			foreach (var item in controls.Concat(buttons))
    			{
    				item.Left = 8;
    				item.Top = y += 8;
    				form.Controls.Add(item);
    				y = item.Bottom;
    			}
    			Application.Run(form);
    		}
    	}
    }
