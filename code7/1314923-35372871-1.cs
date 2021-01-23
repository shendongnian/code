    Ping ipping = new Ping();
    PingReply replyab01 = ipping.Send(abilene01, 1000);
    if (replyab01 != null)
    {
        ZplPrinterStatus.Items.Add("Abilene Primary(01) Printer Status:" + replyab01.Status);
    }
    else
    {
        ListItem item = new ListItem("Abilene Primary(01) Printer Status:" + "Error Printer Time out");
        item.Attributes["style"] = "color:red;";
        ZplPrinterStatus.Items.Add(item);
        // ZplDownSatus.Visible = true;
    }
