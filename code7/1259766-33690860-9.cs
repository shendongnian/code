    // Update methods for each path node used in binding steps.
    private void Update_(global::xBindWithConverter.Item obj, int phase)
    {
        if (obj != null)
        {
            if ((phase & (NOT_PHASED | (1 << 0))) != 0)
            {
                this.Update_Name(obj.Name, phase);
            }
        }
    }
    private void Update_Name(global::System.String obj, int phase)
    {
        if((phase & ((1 << 0) | NOT_PHASED )) != 0)
        {
            XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj3.Target as global::Windows.UI.Xaml.Controls.TextBlock, (global::System.String)this.LookupConverter("ItemConvert").Convert(obj, typeof(global::System.String), null, null), null);
        }
    }
