    public class SignWithToken   {
        public void Sign(String src, String dest,
                         ICollection<X509Certificate> chain, X509Certificate2 pk,
                         String digestAlgorithm, CryptoStandard subfilter,
                         String reason, String location,
                         ICollection<ICrlClient> crlList,
                         IOcspClient ocspClient,
                         ITSAClient tsaClient,
                         int estimatedSize, int RowIdx, int RowHeight, int x, int y, int NameWidth, int DateWidth, 
                         String RevIndex, String RevStep, String Reason, String Name, String Date)
        {
            // Creating the reader and the stamper
            PdfReader reader = null;
            PdfStamper stamper = null;
            FileStream os = null;
            try
            {
                reader = new PdfReader(src);
                os = new FileStream(dest, FileMode.Create);
                // os = new FileStream(dest, FileMode.Create, FileAccess.Write);
                //Activate MultiSignatures
                stamper = PdfStamper.CreateSignature(reader, os, '\0', null, true);
                //To disable Multi signatures uncomment this line : every new signature will invalidate older ones !
                //stamper = PdfStamper.CreateSignature(reader, os, '\0');
                // Creating the appearance
                PdfSignatureAppearance appearance = stamper.SignatureAppearance;
                Rectangle rectangle = new Rectangle(x, y + RowIdx * RowHeight, x + NameWidth + DateWidth, y + (RowIdx+1) * RowHeight);
                appearance.SetVisibleSignature(rectangle, 1, "Revision " + RevIndex + "|" + RevStep);
                appearance.Reason = "marked as changed";
                appearance.Location = location;
                appearance.Layer2Text = "Signed on " + DateTime.Now;
                appearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.DESCRIPTION;
                PdfTemplate n2 = appearance.GetLayer(2);
                Font font = new Font();
                font.SetColor(255, 0, 0);
                font.Size = 10;
                ColumnText ct1 = new ColumnText(n2);
                ct1.SetSimpleColumn(new Phrase(Name, font), 0, 0, NameWidth, rectangle.Height, 15, Element.ALIGN_LEFT);
                ct1.Go();
                ColumnText ct2 = new ColumnText(n2);
                ct2.SetSimpleColumn(new Phrase(Date, font), NameWidth, 0, rectangle.Width, rectangle.Height, 15, Element.ALIGN_LEFT);
                ct2.Go();
                //n2.ConcatCTM(1, 0, 0, -1, 0, 0);
                //n2.SaveState();
                // Creating the signature
                IExternalSignature pks = new X509Certificate2Signature(pk, digestAlgorithm);
                MakeSignature.SignDetached(appearance, pks, chain, crlList, ocspClient, tsaClient, estimatedSize, subfilter);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GMA: " + ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (stamper != null)
                    stamper.Close();
                if (os != null)
                    os.Close();
            }
        }
    }
