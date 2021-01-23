    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    namespace CloneControls {
    	public partial class Form1: Form {
    		public Form1() { InitializeComponent(); }
    		private void Form1_Load(object sender, EventArgs e) {
    			dataGridView1.Rows.Add();
    			dataGridView1.Rows.Add();
    			foreach(Control c in splitContainer1.Panel1.Controls)
    				splitContainer1.Panel2.Controls.Add((Control)Clone(c));
    		}
    
    		static object Clone(object o) {
    			return Copy(o, Activator.CreateInstance(o.GetType()));
    		}
    		static object Copy(object src, object dst) {
    			IList list = src as IList;
    			if(list != null) {
    				IList to = dst as IList;
    				foreach(var x in list)
    					to.Add(Clone(x));
    				return dst; }
    			foreach(PropertyDescriptor pd in TypeDescriptor.GetProperties(src)) {
    				if(!pd.ShouldSerializeValue(src)) {
    					if(src is DataGridView && pd.Name == "Rows")
    						CopyDataGridRows((DataGridView)src, (DataGridView)dst);
    					continue; }
    				switch(pd.SerializationVisibility) {
    				default: continue;
    				case DesignerSerializationVisibility.Visible:
    					if(pd.IsReadOnly) continue;
    					pd.SetValue(dst, pd.GetValue(src));
    					continue;
    				case DesignerSerializationVisibility.Content:
    					Copy(pd.GetValue(src), pd.GetValue(dst));
    					continue;
    				}
    			}
    			return dst;
    		}
    		static void CopyDataGridRows(DataGridView src, DataGridView dst) {
    			foreach(DataGridViewRow row in src.Rows)
    				if(!row.IsNewRow) dst.Rows.Add((DataGridViewRow)Clone(row));
    		}
    	}
    }
