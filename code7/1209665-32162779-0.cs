        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;
        
        namespace Opulos.Core.UI {
        
        public class FormDgvNud : Form {
        	DataGridView dgv = new DataGridViewNumericUpDown { Dock = DockStyle.Fill };
        	public FormDgvNud() {
        		Controls.Add(dgv);
        	}
        }
        
        public class DataGridViewNumericUpDown : DataGridView {
        	public DataGridViewNumericUpDown() : base() {
        		Columns.Add(new NumericUpDownColumn() { HeaderText = "NUD1", DataPropertyName = "Column1", Name = "Column1" });
        		Rows.Add();
        	}
        }
        
        public class NumericUpDownColumn : DataGridViewColumn {
        
        	public NumericUpDownColumn() : base(new NumericUpDownCell()) {
        		this.ValueType = typeof(decimal?);
        	}
        
        	public override DataGridViewCell CellTemplate {
        		get {
        			return base.CellTemplate;
        		}
        		set {
        			if (!(value is NumericUpDownCell))
        				throw new InvalidCastException("Must be a NumericUpDownCell");
        
        			base.CellTemplate = value;
        		}
        	}
        }
        
        public class NumericUpDownCell : DataGridViewTextBoxCell {
        
        	public override void InitializeEditingControl(int rowIndex, Object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle) {
        		// required to initialize the editing control:
        		base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
        		var ctl = (NumericUpDownEditingControl) DataGridView.EditingControl;
        		//NumericUpDownColumn cc = (NumericUpDownColumn) this.OwningColumn;
        		if (this.Value == null || this.Value == DBNull.Value) {
        			ctl.Value = (ctl.Minimum <= 0 && ctl.Maximum >= 0 ? 0 : ctl.Minimum);
        		}
        		else {
        			Object trueValue = this.Value;
        			ctl.Value = (decimal) trueValue;
        		}
        	}
        
        	public override Type EditType {
        		get {
        			return typeof(NumericUpDownEditingControl);
        		}
        	}
        
        	public override Type ValueType {
        		get {
        			return base.ValueType;
        		}
        		set {
        			base.ValueType = value;
        		}
        	}
        
        	public override Object DefaultNewRowValue {
        		get {
        			return DBNull.Value;
        		}
        	}
        }
        
        public class NumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl {
        
        	private bool Cancelling = false;
        
        	public NumericUpDownEditingControl() {
        	}
        
        	// Implements the IDataGridViewEditingControl.EditingControlFormattedValue property.
        	public Object EditingControlFormattedValue {
        		get {
        			// must return a String
        			// it doesn't matter if the value is formatted, it will be replaced
        			// by the formatting events
        			String s = "" + this.Value.ToString();
        			return s;
        		}
        
        		set {
        			decimal val = 0;
        			if (value is decimal)
        				this.Value = (decimal) value;
        			else {
        				String s = "" + value;
        				if (s.Length > 0) {
        					if (decimal.TryParse(s, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out val))
        						this.Value = val;
        				}
        			}
        		}
        	}
        
        	protected override void OnLeave(EventArgs e) {
        		if (!Cancelling) {
        			var dgv = this.EditingControlDataGridView;
        			var cell = (NumericUpDownCell) dgv.CurrentCell;
        			cell.Value = this.Value;
        		}
        
        		base.OnLeave(e);
        		Cancelling = false;
        	}
        
        	private void ProcessValue(Direction transferFocusDirection) {
        		var dgv = this.EditingControlDataGridView;
        		var cell = (NumericUpDownCell) dgv.CurrentCell;
        
        		if (!Cancelling)
        			cell.Value = this.Value;
        	}
        
        	protected override void OnKeyDown(KeyEventArgs e) {
        		if (e.KeyCode == Keys.Escape) {
        			Cancelling = true;
        			e.Handled = true;
        			e.SuppressKeyPress = true;
        			var dgv = this.EditingControlDataGridView;
        			dgv.CancelEdit();
        			dgv.EndEdit();
        		}
        
        		base.OnKeyDown(e);
        	}
        
        	// Implements the  IDataGridViewEditingControl.GetEditingControlFormattedValue method. 
        	public Object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context) {
        		return EditingControlFormattedValue;
        	}
        
        	// Implements the IDataGridViewEditingControl.ApplyCellStyleToEditingControl method. 
        	public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle) {
        		this.Font = dataGridViewCellStyle.Font;
        		this.ForeColor = dataGridViewCellStyle.ForeColor;
        		this.BackColor = dataGridViewCellStyle.BackColor;
        	}
        
        	// Implements the IDataGridViewEditingControl.EditingControlRowIndex property. 
        	public int EditingControlRowIndex { get; set; }
        
        	// Implements the IDataGridViewEditingControl.EditingControlWantsInputKey method. 
        	public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey) {
        		switch (key & Keys.KeyCode) {
        			case Keys.Left:
        			case Keys.Up:
        			case Keys.Down:
        			case Keys.Right:
        			case Keys.Home:
        			case Keys.End:
        			case Keys.PageDown:
        			case Keys.PageUp:
        			case Keys.Escape:
        				return true;
        			default:
        				return !dataGridViewWantsInputKey;
        		}
        	}
        
        	// Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit method. 
        	public void PrepareEditingControlForEdit(bool selectAll) {
        		// No preparation needs to be done.
        	}
        
        	// Implements the IDataGridViewEditingControl.RepositionEditingControlOnValueChange property. 
        	public bool RepositionEditingControlOnValueChange {
        		get {
        			return false;
        		}
        	}
        
        	// Implements the IDataGridViewEditingControl.EditingControlDataGridView property. 
        	public DataGridView EditingControlDataGridView { get; set; }
        
        	// Implements the IDataGridViewEditingControl.EditingControlValueChanged property. 
        	public bool EditingControlValueChanged { get; set; }
        
        	// Implements the IDataGridViewEditingControl.EditingPanelCursor property. 
        	public Cursor EditingPanelCursor {
        		get {
        			return base.Cursor;
        		}
        	}
        }
        
    
    public enum Direction {
    	Down = 0,
    	Right,
    	Up,
    	Left,
    	None
    }
        }
