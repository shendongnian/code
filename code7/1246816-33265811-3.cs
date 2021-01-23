    var template = new HtmlTemplate(@SetData.FileName);
    var output = template.Render(new
                {
                    TITLE = txtTitle.Text,
                    SKU = txtSku.Text,
                    PRICE = txtPrice.Text,
                    DESC = txtDesc.Text,
                    IMAGE = txtImg.Text
                });
    File.WriteAllText(@GlobalVar.setPath, output);
