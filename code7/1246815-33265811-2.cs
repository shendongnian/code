    var template = new HtmlTemplate(@SetData.FileName);
    File.WriteAllText(@GlobalVar.setPath, template.Render(new
                {
                    TITLE = txtTitle.Text,
                    SKU = txtSku.Text,
                    PRICE = txtPrice.Text,
                    DESC = txtDesc.Text,
                    IMAGE = txtImg.Text
                });
