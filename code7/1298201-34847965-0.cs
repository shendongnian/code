    DateTimePicker dtp = new DateTimePicker();
    dtp.ID = "someID";
    //Add some attributes else, if you need. Such as a width, height, so on.
    panel.Controls.Add(new LiteralControl("<td>"));
    panel.Controls.Add(dtp);
    panel.Controls.Add(new LiteralControl("</td>"));
