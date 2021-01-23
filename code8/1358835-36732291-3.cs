    protected void Page_Init(object sender, EventArgs e)
    {
        var skinCombo = RadSkinManager.GetSkinChooser();
        skinCombo.Items.Add(new RadComboBoxItem("Metro Red", "MetroRed"));
    }
