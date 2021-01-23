    // Let's assume that 'plc' is a placeholder. But it can be any control.
    plc.Controls.Add(new LiteralControl("<li class=\"htab-list__item--fininfo active\">"));
    plc.Controls.Add(new LiteralControl("<a href=\"#financial-result\" class=\"htab-list__link tab-link\">"));
    plc.Controls.Add(new CMSEditableRegion { ID = "someid", RegionType = CMSEditableRegionTypeEnum.TextBox, RegionTitle = "sometitle" });
    plc.Controls.Add(new LiteralControl("</li>"));
