    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        try
        {
            mshtml.IHTMLInputElement email = (mshtml.IHTMLInputElement)webFacebook.Document.GetElementById("email").DomElement;
            MessageBox.Show(email.value);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
