    private void ClickLoginButton()
    {
        Invoke(new MethodInvoker(() =>
        {
            try
            {
                if (_mainDialog.WebBrowser.Document == null) return;
                var col = _mainDialog.WebBrowser.Document.GetElementsByTagName("input");
                foreach (var element in col.Cast<HtmlElement>().Where(element => element.Name.Trim().Equals("") || element.Name.Trim().Equals("login")))
                {
                    element.InvokeMember("click");
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }));
    }
