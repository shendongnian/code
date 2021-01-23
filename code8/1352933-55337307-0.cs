ContactData generator = new ContactData(ContactData.ContactOutputType.VCard3, "John", "Doe");
string payload = generator.ToString();
QRCodeGenerator qrGenerator = new QRCodeGenerator();
QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
QRCode qrCode = new QRCode(qrCodeData);
var qrCodeAsBitmap = qrCode.GetGraphic(20);
