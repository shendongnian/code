    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Reflection;
    
    namespace SimpleForm {
    
    public class FormA : Form {
    
    	Button btn1 = new Button { Text = "Button1" };
    
    	public FormA() {
    		Controls.Add(btn1);
    
    		Button btn1a = new Button { Text = "Button1a" }; // not colored
    		btn1a.Location = new Point(0, 50);
    		Controls.Add(btn1a);
    	}
    }
    
    public class FormB : FormA {
    
    	Button btn2 = new Button { Text = "Button2" };
    
    	public FormB() {
    		btn2.Location = new Point(0, 100);
    		Controls.Add(btn2);
    		btn2.Click += delegate {
    			ColorIt.ColorControls(this);
    		};
    	}
    }
    
    public static class ColorIt {
    
    	private static void GetAllControls(Control c, List<Control> list) {
    		// only pick controls that have no children (e.g. button, textbox, etc)
    		if (c.Controls.Count == 0)
    			list.Add(c);
    		else
    			foreach (Control c2 in c.Controls)
    				GetAllControls(c2, list);
    	}
    
    	public static void ColorControls(Control parent) {
    		
    		Type[] fs = new [] { typeof(FormA), typeof(FormB) };
    		Color[] colors = new [] { Color.Red, Color.Blue };
    		List<Control> controls = new List<Control>();
    		GetAllControls(parent, controls);
    
    		foreach (Control c in controls) {
    			Type t = c.GetType();
    			for (int i = 0; i < fs.Length; i++) {
    				Type f = fs[i];
    				Color clr = colors[i];
    
    				foreach (var pi in f.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) {
    					if (pi.PropertyType == t && pi.GetValue(parent) == c) {
    						c.ForeColor = clr;
    						c.BackColor = clr;
    					}
    				}
    				foreach (var fi in f.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) {
    					if (fi.FieldType == t && fi.GetValue(parent) == c) {
    						c.ForeColor = clr;
    						c.BackColor = clr;
    					}
    				}
    			}
    		}
    	}
    }
