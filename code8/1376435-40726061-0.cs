    if (para.InnerText == "Functional Requirements:")
    {
        //--We remove the current texts of the paragraph, a new one will be added within the hyperlink
        foreach (OpenXmlProcess.Text tes in para.Descendants<OpenXmlProcess.Text>().ToList()) 
        {
            tes.Remove();
        }
         //-------------Apply some style--------------
         OpenXmlProcess.RunFonts runFont = new OpenXmlProcess.RunFonts();
         runFont.EastAsia = "Arial";
         OpenXmlProcess.FontSize size = new OpenXmlProcess.FontSize();
         size.Val = new OpenXML.StringValue("20");
         //-------------------------------------------
         OpenXmlProcess.Hyperlink hyp = new OpenXmlProcess.Hyperlink() { History = true, Anchor = "Mop" }; //--Point to the bookmark
         OpenXmlProcess.Run ruG = new OpenXmlProcess.Run() { RsidRunProperties = "00D56462" };
         OpenXmlProcess.RunProperties runProp = new OpenXmlProcess.RunProperties();
         OpenXmlProcess.RunStyle rnStyl = new OpenXmlProcess.RunStyle() { Val = "Hyperlink" };
         runProp.Append(rnStyl);
         runProp.Append(runFont);
         runProp.Append(size);
         //----Create a new text with our original string and append it to the hyperlink
         OpenXmlProcess.Text txL = new OpenXmlProcess.Text();
         txL.Text = "Functional Requirements:";
         ruG.Append(runProp);
         ruG.Append(txL);
         hyp.Append(ruG);
         para.Append(hyp); //Append the hyperlink to our paragraph
    }
