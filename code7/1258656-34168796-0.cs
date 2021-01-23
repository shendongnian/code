            //how to handle checking multiple checkboxes with same name
            var ck = form.Fields["chkbox"];
            if (ck.HasKids)
            {
                foreach (var item in ck.Fields.Elements.Items) {
                    //assumes you want to "check" the checkbox.  Use "/Off" if you want to uncheck.
                    //"/Yes" is defined in your pdf document as the checked value.  May vary depending on original pdf creator.
                    ((PdfDictionary)(((PdfReference)(item)).Value)).Elements.SetName(PdfAcroField.Keys.V, "/Yes");
                    ((PdfDictionary)(((PdfReference)(item)).Value)).Elements.SetName(PdfAnnotation.Keys.AS, "/Yes");
                }
            }
            else {
                ((PdfCheckBoxField)(form.Fields["chkbox"])).Checked = true;
            }
