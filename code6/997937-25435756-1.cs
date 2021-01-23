    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    public class Form2 : Form {
    	NotifyIcon myNotifyIcon = new NotifyIcon() { Icon = SystemIcons.Exclamation };
    	MenuItem entQuit = new MenuItem("Menu Item Text");
    	MenuItem entQuit2 = new MenuItem("Menu Item Text2");
    	List<Rectangle> rectangles = new List<Rectangle>();
    	
    	public Form2() {
    		//ContextMenuStrip cms;
    		myNotifyIcon.Click += myNotifyIcon_Click;
    		entQuit.Click += entQuit_Click;
    
    		var cm = new ContextMenu();
    		myNotifyIcon.ContextMenu = cm;
    		myNotifyIcon.ContextMenu.MenuItems.Add(entQuit);
    		myNotifyIcon.ContextMenu.MenuItems.Add(entQuit2);
    		myNotifyIcon.Visible = true;
    
    		myNotifyIcon.ContextMenu.Popup += delegate {
    			this.BeginInvoke((Action) delegate {
    				var h = myNotifyIcon.ContextMenu.Handle;
    				rectangles = new List<Rectangle>();
    
    				for (int i = 0; i < cm.MenuItems.Count; i++) {
    					RECT cr = new RECT();
    					GetMenuItemRect(IntPtr.Zero, h, (uint) i, ref cr);
    					rectangles.Add(new Rectangle(cr.Left, cr.Top, cr.Right - cr.Left, cr.Bottom - cr.Top));
    				}
    			});
    		};
    	}
    
    	void entQuit_Click(object sender, EventArgs e) {
    	}
    
    	void myNotifyIcon_Click(object sender, EventArgs e) {
    		bool OnMenuItem = false;
    		var mp = Form.MousePosition;
    		foreach (var r in rectangles) {
    			if (r.Contains(mp)) {
    				OnMenuItem = true;
    				break;
    			}
    		}
    		// reset rectangles to prevent icon click from scanning previous rectangles
    		rectangles = new List<Rectangle>();
    
    		if (OnMenuItem) { // detect if click was on a menu item
    			return;
    		}
    	}
    
    	[DllImport("user32.dll")]
    	static extern bool GetMenuItemRect(IntPtr hWnd, IntPtr hMenu, uint uItem, ref RECT rect);
    
    	[StructLayout(LayoutKind.Sequential)]
    	public struct RECT {
    		public int Left;
    		public int Top;
    		public int Right;
    		public int Bottom;
    	}
    }
