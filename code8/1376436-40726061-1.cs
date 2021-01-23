    if (para.InnerText == "Functional Requirements:")
    {
         //--We remove the current text, a new one will be added within the hyperlink
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
         OpenXmlProcess.Run ruG = new OpenXmlProcess.Run() { RsidRunProperties = "00D56462" };
         OpenXmlProcess.RunProperties runProp = new OpenXmlProcess.RunProperties();
         runProp.Append(runFont);
         runProp.Append(size);
         //----Create a new text with our original string
         OpenXmlProcess.Text txL = new OpenXmlProcess.Text();
         txL.Text = "Functional Requirements:";
         ruG.Append(runProp);
         ruG.Append(txL);
         para.Append(ruG);
    }
