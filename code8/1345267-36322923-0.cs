        protected void btWyswietl_Click(object sender, EventArgs e)
        {
            var encoded = HttpUtility.HtmlEncode(tbTekst.Text);
            using (System.IO.StringWriter stringWriter = new StringWriter())
            {
                using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);
                    writer.WriteEncodedText(encoded);
                    writer.RenderEndTag();
                }
               
                lbTekstPo.Text = stringWriter.ToString();
            }
        }
