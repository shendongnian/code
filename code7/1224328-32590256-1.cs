    HtmlInputRadioButton btn = new HtmlInputRadioButton();
    btn.ID = mapGenieImage;
    btn.Value = mapGenieImage;
    btn.Visible = false;
    btn.attributes.add("onclick","addLayer()")  '<-- Add me.
    cell.Controls.Add(btn);
