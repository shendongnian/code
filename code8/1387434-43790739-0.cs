    private string ConvertSignatureToBase64()
        {
            try
            {
                byte[] data;
                if(Device.OS == TargetPlatform.iOS)
                {
                    var img = SignaturePad.GetImage(Acr.XamForms.SignaturePad.ImageFormatType.Jpg);
                    var signatureMemoryStream = new MemoryStream();
                    img.CopyTo(signatureMemoryStream);
                    data = signatureMemoryStream.ToArray();
                }
                else
                {
                    var img = SignaturePad.GetImage(Acr.XamForms.SignaturePad.ImageFormatType.Jpg);
                    var signatureMemoryStream = (MemoryStream)img;
                    data = signatureMemoryStream.ToArray();
                }
                return Convert.ToBase64String(data);      
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
