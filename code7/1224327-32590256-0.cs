    HtmlInputRadioButton btn = new HtmlInputRadioButton();
    btn.ID = mapGenieImage;
    btn.Value = mapGenieImage;
    btn.Visible = false;
    btn.attributes.add("onclick","addLayer()")
    cell.Controls.Add(btn);
