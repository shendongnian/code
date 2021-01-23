    private void Form1_Load(object sender, EventArgs e)
    {
        this.myBindingSource.DataSource = new SampleModel();
        var bindingManager = this.BindingContext[this.myBindingSource];
        bindingManager.BindingComplete += bindingManager_BindingComplete;
    }
    Dictionary<Control, Color> Items = new Dictionary<Control, Color>();
    private void bindingManager_BindingComplete(object sender, BindingCompleteEventArgs e)
    {
        var control = e.Binding.Control;
        //Store Original BackColor
        if (!Items.ContainsKey(control))
            Items[control] = control.BackColor;
        //Check If there is an error
        if (!string.IsNullOrEmpty(e.ErrorText))
        {
            control.BackColor = Color.Salmon;
            this.errorToolTip.SetToolTip(control, e.ErrorText);
        }
        else
        {
            e.Binding.Control.BackColor = Items[e.Binding.Control];
            this.errorToolTip.SetToolTip(control, null);
        }
    }
