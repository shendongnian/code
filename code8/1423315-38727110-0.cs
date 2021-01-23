       if(txtField.Elements.ContainsKey("/DA") == false)
          {
             txtField.Elements.Add("/DA", new PdfString("/CoBo 12 Tf 0 g"));
          }
       else
          {
             txtField.Elements["/DA"] = new PdfString("/CoBo 12 Tf 0 g");
          }
