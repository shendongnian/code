    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Reflection;
    
    namespace WindowsFormsApplication1 {
      public partial class Form1 : Form, IMessageFilter {
        public Form1() {
          InitializeComponent();
          Application.AddMessageFilter(this);
          errorProvider1.SetError(textBox1, "Test");
        }
    
        protected override void OnFormClosing(FormClosingEventArgs e) {
          Application.RemoveMessageFilter(this);
          base.OnFormClosing(e);
        }
    
        public bool PreFilterMessage(ref Message m) {
          if (m.Msg == 0x201) {
            // MouseDown, check if the icon was clicked
            NativeWindow wnd = NativeWindow.FromHandle(m.HWnd);
            if (wnd == null) return false;
            Type t = wnd.GetType();
            if (t.Name != "ErrorWindow") return false;
            // Yes, use Reflection to find the control for that icon
            FieldInfo fi = t.GetField("items", BindingFlags.NonPublic | BindingFlags.Instance);
            System.Collections.ArrayList items = fi.GetValue(wnd) as System.Collections.ArrayList;
            if (items == null || items.Count == 0) return false;
            object item = items[0];
            FieldInfo fi2 = item.GetType().GetField("control", BindingFlags.NonPublic | BindingFlags.Instance);
            Control ctl = fi2.GetValue(item) as Control;
            // Got it.
            MessageBox.Show("You clicked the icon for " + ctl.Name);
          }
          return false;
        }
      }
    }
