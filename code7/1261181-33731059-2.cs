    protected void Page_Load(object sender, EventArgs e) {
      Rebind();
    }
    protected IList<ControlDescriptor> Descriptors {
      get {
        var result = (IList<ControlDescriptor>)ViewState["Descriptors"];
        if (result == null) {
          result = new List<ControlDescriptor>();
          ViewState["Descriptors"] = result;
        }
        return result;
      }
    }
    protected void Rebind() {
      rptControls.DataSource = Descriptors;
      rptControls.DataBind();
    }
    protected void btnAddCheckBox_Click(object sender, EventArgs e) {
      Descriptors.Add(new CheckBoxDescriptor { Text = txtText.Text });
      Rebind();
    }
    protected void btnAddLabel_Click(object sender, EventArgs e) {
      Descriptors.Add(new LabelDescriptor { Text = txtText.Text });
      Rebind();
    }
    protected void rptControls_ItemDataBound(object sender, RepeaterItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item ||
        e.Item.ItemType == ListItemType.AlternatingItem) {
        var descriptor = (ControlDescriptor)e.Item.DataItem;
        descriptor.SetupControl(e.Item.Controls);
      }
    }
