    <asp:CheckBox id="LineQuantity" runat="server" OnDataBinding="LineQuantity_DataBinding" />
    protected void LineQuantity_DataBinding(object sender, System.EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        chk.Checked = (bool)(Eval("SomeField"));  // Note you can use Eval here...
        chk.Visible = showField();
    }
    
