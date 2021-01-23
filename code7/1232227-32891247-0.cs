    public class DocumentSigner
    {
        private const string _datetimeFormat = "dd/MM/yyyy hh:mm:ss";
        public byte[] Sign(ICollection<X509Certificate> chain, ICipherParameters pk, string signingBlock, byte[] document, bool certify, String pattern = null)
        {
            document = AddMetaData(document);
            if (pattern != null)
                File.WriteAllBytes(String.Format(pattern, "1"), document);
            document = AddSignatureFields(signingBlock, document);
            if (pattern != null)
                File.WriteAllBytes(String.Format(pattern, "2"), document);
            return SignDocument(chain, pk, signingBlock, document, certify);
        }
        private byte[] AddMetaData(byte[] document)
        {
            return document;
        }
        private byte[] AddSignatureFields(string signingBlock, byte[] document)
        {
                using (MemoryStream outputStream = new MemoryStream())
                {
                    using (PdfReader reader = new PdfReader(document))
                    {
                        using (PdfStamper stamper = new PdfStamper(reader, outputStream, '\0', true))
                        {
                            CreateSignatureField(reader, stamper, signingBlock);
                        }
                    }
                    document = outputStream.ToArray();
                }
            return document;
        }
        private PdfSignatureAppearance CreatePdfAppearance(PdfStamper stamper, bool certify)
        {
            PdfSignatureAppearance appearance = stamper.SignatureAppearance;
            appearance.Location = "information.Location";
            appearance.Reason = "information.Purpose";
            appearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.DESCRIPTION;
            CreatePdfAppearanceCertifyDocument(appearance, certify);
            return appearance;
        }
        private void CreatePdfAppearanceCertifyDocument(PdfSignatureAppearance appearance, bool certify)
        {
            if (certify)
            {
                appearance.CertificationLevel = PdfSignatureAppearance.CERTIFIED_FORM_FILLING;
            }
            else
            {
                appearance.CertificationLevel = PdfSignatureAppearance.NOT_CERTIFIED;
            }
        }
        private PdfStamper CreatePdfStamper(PdfReader reader, MemoryStream outputStream, byte[] document)
        {
            return PdfStamper.CreateSignature(reader, outputStream, '\0', null, true);
        }
        private void CreateSignatureField(PdfReader reader, PdfStamper stamper, string signingBlock)
        {
            if (signingBlock == null)
            {
                return;
            }
            if (!DoesSignatureFieldExist(reader, signingBlock))
            {
                PdfFormField signatureField = PdfFormField.CreateSignature(stamper.Writer);
                signatureField.SetWidget(new Rectangle(100, 100, 200, 200), null);
                signatureField.Flags = PdfAnnotation.FLAGS_PRINT;
                signatureField.FieldName = signingBlock;
                signatureField.Page = 1;
                stamper.AddAnnotation(signatureField, 1);
            }
        }
        private bool DoesSignatureFieldExist(PdfReader reader, string signatureFieldName)
        {
            if (String.IsNullOrWhiteSpace(signatureFieldName))
            {
                return false;
            }
            return reader.AcroFields.DoesSignatureFieldExist(signatureFieldName);
        }
        private byte[] GetSignatureImage(string signingBlockName)
        {
            return null;
        }
        private byte[] SignDocument(ICollection<X509Certificate> chain, ICipherParameters pk, string signingBlock, byte[] document, bool certify)
        {
                using (MemoryStream outputStream = new MemoryStream())
                {
                    using (PdfReader reader = new PdfReader(document))
                    {
                        using (PdfStamper stamper = CreatePdfStamper(reader, outputStream, document))
                        {
                            PdfSignatureAppearance appearance = CreatePdfAppearance(stamper, certify);
                            SignDocumentSigningBlock(chain, pk, signingBlock, appearance, stamper, GetSignatureImage(signingBlock));
                        }
                    }
                    document = outputStream.ToArray();
                }
            return document;
        }
        private void SignDocumentSigningBlock(ICollection<X509Certificate> chain, ICipherParameters pk, string block, PdfSignatureAppearance appearance, PdfStamper stamper, byte[] signatureImage)
        {
            appearance.SetVisibleSignature(block);
            SignDocumentSigningBlockWithImage(signatureImage, appearance);
            SignDocumentSigningBlockWithText(appearance, chain.First());
            IExternalSignature externalSignature = new PrivateKeySignature(pk, "SHA-256");
            MakeSignature.SignDetached(appearance, externalSignature, chain, null, null, new TSAClientBouncyCastle("http://services.globaltrustfinder.com/adss/tsa"), 104000, CryptoStandard.CMS);
        }
        private void SignDocumentSigningBlockWithImage(byte[] signatureImage, PdfSignatureAppearance appearance)
        {
            if (signatureImage != null && signatureImage.Length > 0)
            {
                Image signatureImageInstance = Image.GetInstance(signatureImage);
                appearance.Image = signatureImageInstance;
                appearance.SignatureGraphic = signatureImageInstance;
            }
        }
        private void SignDocumentSigningBlockWithText(PdfSignatureAppearance appearance, X509Certificate x509Certificate)
        {
            if (x509Certificate == null)
            {
                return;
            }
            appearance.Layer2Text = SignDocumentSigningBlockWithTextBuildText(x509Certificate);
            appearance.Layer2Font = new Font(Font.FontFamily.COURIER, 7.0f, Font.NORMAL, BaseColor.LIGHT_GRAY);
            appearance.Acro6Layers = true;
        }
        private string SignDocumentSigningBlockWithTextBuildText(X509Certificate x509Certificate)
        {
            Dictionary<string, string> fields = SignDocumentSigningBlockWithTextBuildTextIssuerFields(x509Certificate.IssuerDN.ToString());
            string organization = fields.Keys.Contains("O") ? fields["O"] : String.Empty;
            string commonName = fields.Keys.Contains("CN") ? fields["CN"] : String.Empty;
            string signDate = System.DateTime.Now.ToString(_datetimeFormat);
            string expirationDate = x509Certificate.NotAfter.ToString();
            return "Digitally signed by " + organization + "\nSignee: " + commonName + "\nSign date: " + signDate + "\n" + "Expiration date: " + expirationDate;
        }
        private Dictionary<string, string> SignDocumentSigningBlockWithTextBuildTextIssuerFields(string issuer)
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            string[] issuerFields = issuer.Split(',');
            foreach (string field in issuerFields)
            {
                string[] fieldSplit = field.Split('=');
                string key = fieldSplit[0].Trim();
                string value = fieldSplit[1].Trim();
                if (!fields.Keys.Contains(key))
                {
                    fields.Add(key, value);
                }
                else
                {
                    fields[key] = value;
                }
            }
            return fields;
        }
    }
