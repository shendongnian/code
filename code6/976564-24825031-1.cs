    private void Button_Click(object sender, RoutedEventArgs e)
            {
                Hyperlink hyperlink = new Hyperlink();
                hyperlink.Inlines.Add(txtInput.Text);
                
                Paragraph myParagraph = new Paragraph();
                myParagraph.Inlines.Add(hyperlink);
                textBox.Blocks.Add(myParagraph);
            }
