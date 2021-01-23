            public ActionResult qrCode (string id)
        {
                string id = Request.Params["ID"];
                QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
                QRCoder.QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode("http://mywebsite.com/profile.aspx?ID="+ id+ "", QRCoder.QRCodeGenerator.ECCLevel.M)
               return FileContentResult(qrCode.GetGraphic(20),"image/png","qrcode.png");
    
        }
