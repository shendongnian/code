    public class ActionLogger
    {
    	private Type _frmType;
    	private Form _frm;
    	/// <summary>
    	/// Ctor Lazy way of hooking up all form control events to listen for user actions.
    	/// </summary>
    	/// /// <param name="frm">The WinForm, WPF, Xamarin, etc Form.</param>
    	public ActionLogger(Control frm)
    	{
    		_frmType = ((Form)frm).GetType();
    		_frm = (Form)frm;
    		ActionLoggerSetUp(frm);
    	}
    
    	/// <summary>
    	/// Ctor Optimal way of hooking up control events to listen for user actions.
    	/// </summary>
    	public ActionLogger(Control[] ctrls)
    	{
    		ActionLoggerSetUp(ctrls);
    	}
    
    	/// <summary>
    	/// Lazy way of hooking up all form control events to listen for user actions.
    	/// </summary>
    	/// /// <param name="frm">The WinForm, WPF, Xamarin, etc Form.</param>
    	public void ActionLoggerSetUp(Control frm)
    	{
    		HookUpEvents(frm);  //First hook up this controls' events, then traversely Hook Up its children's
    		foreach (Control ctrl in frm.Controls) {
    			ActionLoggerSetUp(ctrl); //Recursively hook up control events via the *Form's* child->child->etc controls
    		}
    	}
    
    	/// <summary>
    	/// Optimal way of hooking up control events to listen for user actions.
    	/// </summary>
    	/// <param name="ctrls">The controls on the WinForm, WPF, Xamarin, etc Form.<param>
    	public void ActionLoggerSetUp(Control[] ctrls)
    	{ 
    		foreach (var ctrl in ctrls) {
    			HookUpEvents(ctrl);
    		}
    	}
    	/// <summary>
    	/// Releases the hooked up events (avoiding memory leaks).
    	/// </summary>    	
    	public void ActionLoggerTierDown(Control frm)
    	{
    		ReleaseEvents(frm);
    	}
    
    	/// <summary>
    	/// Hooks up the event(s) needed to debug problems. Feel free to add more Controls like ListView for example subscribe LogAction() to more events.
    	/// </summary>
    	/// <param name="ctrl">The control whose events we're suspicious of causing problems.</param>
    	private void HookUpEvents(Control ctrl)
    	{
    		if (ctrl is Form) {
    			Form frm = ((Form)ctrl);
    			frm.Load += LogAction;
    			frm.FormClosed += LogAction;
    			frm.ResizeBegin += LogAction;
    			frm.ResizeEnd += LogAction;
    		}
    		else if (ctrl is TextBoxBase) {
    			TextBoxBase txt = ((TextBoxBase)ctrl);
    			txt.Enter += LogAction;
    		}
    		else if (ctrl is ListControl) { //ListControl stands for ComboBoxes and ListBoxes.
    			ListControl lst = ((ListControl)ctrl);
    			lst.SelectedValueChanged += LogAction;
    		}
    		else if (ctrl is ButtonBase) { //ButtonBase stands for Buttons, CheckBoxes and RadioButtons.
    		    ButtonBase btn = ((ButtonBase)ctrl);
    		    btn.Click += LogAction;
    		}
            else if (ctrl is DateTimePicker) {
    			DateTimePicker dtp = ((DateTimePicker)ctrl);
    			dtp.Enter += LogAction;
    			dtp.ValueChanged += LogAction;
    		}
    		else if (ctrl is DataGridView) {
    			DataGridView dgv = ((DataGridView)ctrl);
    			dgv.RowEnter += LogAction;
    			dgv.CellBeginEdit += LogAction; 
    			dgv.CellEndEdit += LogAction;
    		}
    	}
    
    	/// <summary>
    	/// Releases the hooked up events (avoiding memory leaks).
    	/// </summary>
    	/// <param name="ctrl"></param>
    	private void ReleaseEvents(Control ctrl)
    	{
    		if (ctrl is Form) {
    			Form frm = ((Form)ctrl);
    			frm.Load -= LogAction;
    			frm.FormClosed -= LogAction;
    			frm.ResizeBegin -= LogAction;
    			frm.ResizeEnd -= LogAction;
    		}
    		else if (ctrl is TextBoxBase) {
    			TextBoxBase txt = ((TextBoxBase)ctrl);
    			txt.Enter -= LogAction;
    		}
    		else if (ctrl is ListControl) {
    			ListControl lst = ((ListControl)ctrl);
    			lst.SelectedValueChanged -= LogAction;
    		}
    		else if (ctrl is DateTimePicker) {
    			DateTimePicker dtp = ((DateTimePicker)ctrl); 
    			dtp.Enter -= LogAction;
    			dtp.ValueChanged -= LogAction;
    		}
    		else if (ctrl is ButtonBase) {
    			ButtonBase btn = ((ButtonBase)ctrl);
    			btn.Click -= LogAction; 
    		}
    		else if (ctrl is DataGridView) {
    			DataGridView dgv = ((DataGridView)ctrl);
    			dgv.RowEnter -= LogAction;
    			dgv.CellBeginEdit -= LogAction; 
    			dgv.CellEndEdit -= LogAction;
    		}
    	}
    
    	/// <summary>
    	/// Log the Control that made the call and its value
    	/// </summary>
    	/// <param name="sender"></param>
    	/// <param name="e"></param>
    	public void LogAction(object sender, EventArgs e)
    	{
    		if (!(sender is Form || sender is ButtonBase || sender is DataGridView)) //Tailor this line to suit your needs
    		{   //dont log control events if its a Maintenance Form and its not in Edit mode
    			if (_frmType.BaseType.ToString().Contains("frmMaint")) {//This is strictly specific to my project - you will need to rewrite this line and possible the line above too. That's all though...
    				PropertyInfo pi = _frmType.GetProperty("IsEditing");
    				bool isEditing = (bool)pi.GetValue(_frm, null);
    				if (!isEditing) return;
    			}
    		}
    		StackTrace stackTrace = new StackTrace();      
    		StackFrame[] stackFrames = stackTrace.GetFrames();
    		var eventType = stackFrames[2].GetMethod().Name;//This depends usually its the 1st Frame but in this particular framework (CSLA) its 2
    		ActionLog.LogAction(_frm.Name, ((Control)sender).Name, eventType, GetSendingCtrlValue(((Control)sender), eventType));
    	}
    
    	private string GetSendingCtrlValue(Control ctrl, string eventType)
    	{
    		if (ctrl is TextBoxBase) {
    			return ((TextBoxBase)ctrl).Text;
    		}
    		//else if (ctrl is CheckBox || ctrl is RadioButton) {
    		//	return  ((ButtonBase)ctrl).Text;
    		//}
    		else if (ctrl is ListControl) {
    			return ((ListControl)ctrl).Text.ToString();
    		}
    		else if (ctrl is DateTimePicker) {
    			return ((DateTimePicker)ctrl).Text;
    		}
    		else if (ctrl is DataGridView && eventType == "OnRowEnter")
    		{
    			if (((DataGridView)ctrl).SelectedRows.Count > 0) {
    				return ((DataGridView)ctrl).SelectedRows[0].Cells[0].Value.ToString();
    			}
    			else {
    				return string.Empty;
    			}
    		}
    		else if (ctrl is DataGridView) {
    			DataGridViewCell cell = (((DataGridView)ctrl).CurrentCell);
    			if (cell == null) return string.Empty;
    			return cell.Value.ToString();
    		}
    		return string.Empty;
    	}
    }
