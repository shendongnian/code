    using SP = Microsoft.SharePoint.Client;
    ...
    using (var context = new SP.ClientContext(new Uri(<YOURSITEURL>))) {
        var web = context.Web;
        context.Credentials = new NetworkCredential(<NETWORK_USERNAME>, <NETWORK_PASS>, <DOMAIN_NAME>);
        context.Load(web);
        try
        {
            context.ExecuteQuery();
        } catch (Exception ex) {
        }
        var file = web.GetFileByServerRelativeUrl(new Uri(<FILE_URL>).AbsolutePath);
        context.Load(file);
        try
        {
            context.ExecuteQuery();
            file.SaveBinary(new SP.FileSaveBinaryInformation() { Content = Encoding.UTF8.GetBytes(<NEW_FILE>) });
            try
            {
                context.ExecuteQuery();
            }
            catch (Exception ex)
            {
            }
        }
    }
