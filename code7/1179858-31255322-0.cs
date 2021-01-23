    mail.AddAttachment(HttpContext.Current.Server.MapPath(
        "~/img/TNTC-Logo.png"), "logo", new ContentType("image/png"));
    mail.AddAttachment(HttpContext.Current.Server.MapPath(
        "~/img/Anfahrt.png"), "anfahrt", new ContentType("image/png"));
    mail.AddHtmlView(HttpContext.Current.Server.MapPath(
        "~/EMail/MailBody.html"), formatParams);
