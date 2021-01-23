    var prop = client.GetType().GetProperty("DeliveryFormat");
    if (prop != null) {
        var enumType = typeof (SmtpClient).Assembly.GetType("System.Net.Mail.SmtpDeliveryFormat");
        prop.SetValue(client, Enum.Parse(enumType, "International"));                                
    }
