    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace System.Windows.Forms
    {
    	public class TreeComboBoxItem
    	{
    		public object Group { get; set; }
    		public object Value { get; set; }
    		private string display;
    		public string Display { get { return display ?? (Value != null ? Value.ToString() : null); } set { display = value; } }
    	}
    	public class DataGridViewTreeComboBoxColumn : DataGridViewComboBoxColumn
    	{
    		public DataGridViewTreeComboBoxColumn()
    		{
    			base.CellTemplate = new TreeComboBoxCell();
    		}
    		public override DataGridViewCell CellTemplate
    		{
    			get { return base.CellTemplate; }
    			set { base.CellTemplate = (TreeComboBoxCell)value; }
    		}
    	}
    	public class TreeComboBoxCell : DataGridViewComboBoxCell
    	{
    		public TreeComboBoxCell() { }
    		public override Type EditType { get { return typeof(TreeComboBoxEditingControl); } }
    		public override void InitializeEditingControl(int rowIndex, object
    			initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
    		{
    			base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
    			var ctl = DataGridView.EditingControl as TreeComboBoxEditingControl;
    			ctl.SetItems(Items);
    			ctl.SelectedNode = Value != null ? ctl.AllNodes.FirstOrDefault(x => Equals(x.Tag, Value)) : null;
    			ctl.SelectedNodeChanged += OnEditorSelectedNodeChanged;
    		}
    		public override void DetachEditingControl()
    		{
    			var ctl = DataGridView.EditingControl as TreeComboBoxEditingControl;
    			if (ctl != null) ctl.SelectedNodeChanged -= OnEditorSelectedNodeChanged;
    			base.DetachEditingControl();
    		}
    		public override object Clone()
    		{
    			var dataGridViewCell = base.Clone() as TreeComboBoxCell;
    			if (dataGridViewCell != null)
    			{
    			}
    			return dataGridViewCell;
    		}
    		protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
    		{
    			if (value != null)
    			{
    				foreach (TreeComboBoxItem item in Items)
    					if (Equals(item.Value, value)) return (context & DataGridViewDataErrorContexts.Formatting) != 0 ? item.Display : value;
    			}
    			return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
    		}
    		public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter)
    		{
    			return formattedValue;
    		}
    		private void OnEditorSelectedNodeChanged(object sender, EventArgs e)
    		{
    			var selectedNode = ((TreeComboBoxEditingControl)sender).SelectedNode;
    			Value = selectedNode != null ? selectedNode.Tag : null;
    		}
    	}
    	public class TreeComboBoxEditingControl : ComboTreeBox, IDataGridViewEditingControl
    	{
    		public TreeComboBoxEditingControl() { TabStop = false; }
    		public DataGridView EditingControlDataGridView { get; set; }
    		public int EditingControlRowIndex { get; set; }
    		public bool EditingControlValueChanged { get; set; }
    		public bool RepositionEditingControlOnValueChange { get { return false; } }
    		public Cursor EditingPanelCursor { get { return Cursor; } }
    		public void SetItems(DataGridViewComboBoxCell.ObjectCollection items)
    		{
    			if (Nodes.Count > 0) return;
    			foreach (var group in items.Cast<TreeComboBoxItem>().GroupBy(x => x.Group))
    			{
    				var parent = Nodes.Add(group.Key.ToString());
    				foreach (var item in group)
    					parent.Nodes.Add(item.Display).Tag = item.Value;
    			}
    			Sort();
    		}
    		protected override void OnSelectedNodeChanged(EventArgs e)
    		{
    			EditingControlValueChanged = true;
    			EditingControlDataGridView.NotifyCurrentCellDirty(true);
    			base.OnSelectedNodeChanged(e);
    		}
    		public object EditingControlFormattedValue
    		{
    			get { return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting); }
    			set
    			{
    			}
    		}
    		public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
    		{
    			if (SelectedNode == null) return null;
    			return (context & DataGridViewDataErrorContexts.Formatting) != 0 ? SelectedNode.Text : SelectedNode.Tag;
    		}
    		public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
    		{
    			BackColor = dataGridViewCellStyle.BackColor;
    			ForeColor = dataGridViewCellStyle.ForeColor;
    		}
    		public void PrepareEditingControlForEdit(bool selectAll)
    		{
    		}
    		public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
    		{
    			switch (key & Keys.KeyCode)
    			{
    				case Keys.Left:
    				case Keys.Up:
    				case Keys.Down:
    				case Keys.Right:
    				case Keys.Home:
    				case Keys.End:
    				case Keys.PageDown:
    				case Keys.PageUp:
    					return true;
    				default:
    					return !dataGridViewWantsInputKey;
    			}
    		}
    	}
    }
    namespace Tests
    {
    	class Parent
    	{
    		public string Name { get; set; }
    		public override string ToString() { return Name; }
    	}
    	class Child
    	{
    		public Parent Parent { get; set; }
    		public string Name { get; set; }
    	}
    	class TestForm : Form
    	{
    		public TestForm()
    		{
    			var parents = Enumerable.Range(1, 6).Select(i => new Parent { Name = "Parent " + i }).ToList();
    			var childen = Enumerable.Range(1, 10).Select(i => new Child { Parent = parents[i % parents.Count], Name = "Child " + i }).ToList();
    			var items = parents.Select((parent, i) => new TreeComboBoxItem { Value = parent, Group = "Group " + ((i % 2) + 1) }).ToArray();
    			var dg = new DataGridView { Dock = DockStyle.Fill, Parent = this, AutoGenerateColumns = false };
    			var c1 = new DataGridViewTreeComboBoxColumn { DataPropertyName = "Parent", HeaderText = "Parent" };
    			c1.Items.AddRange(items);
    			var c2 = new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name" };
    			dg.Columns.AddRange(c1, c2);
    			dg.DataSource = new BindingList<Child>(childen);
    		}
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			Application.Run(new TestForm());
    		}
    	}
    }
