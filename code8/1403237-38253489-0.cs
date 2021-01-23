    int lblpositionX = 17;
    int lblpositionY = 39;
    int increment = 0;
    string[] arr1 = {};
    foreach (XElement Name in XDocumentName.Root.Descendants())
    {
       Label lbl = new Label();
       lbl.Text = Name.ToString();
       lbl.Name = Name.ToString();
       lbl.Location = new Point(lblpositionX, lblpositionY);
       lblpositionY += 25;
    
       TextBox txt = new TextBox();
       txt.Text = Name.Value.ToString();
       txt.Name = "XML_Text" + increment;
       txt.Location = new Point(txtpositionX, txtpositionY);
       txtpositionY += 25;
       
       pnl_XML.Controls.Add(lbl);
       pnl_XML.Controls.Add(txt);
    }
    private void btn_Save_Click(object sender, EventArgs e)
    {
       var textboxes = pnl_XML.Controls.OfType<TextBox>().Select(Control => Control.Text);
       arr1 = textboxes.ToArray();
       int textBox = textboxes.Count();
       for (int i = 0; i < textBox; i++)
       {
          foreach (XElement Name in XDocumentName.Descendants())
          {
             Name.Value = arr[i];
             i++
          }
          XDocumentName.Save(pathofXML);
          return;
       }
    }
