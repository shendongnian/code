    var linkField = (LinkField)foundAlias.Fields["linked item"];
    var targetUrl = linkField.Url;
    using (new SecurityDisabler()) 
    {
        if (string.IsNullOrEmpty(targetUrl) && linkField.TargetItem != null)
           targetUrl = LinkManager.GetItemUrl(linkField.TargetItem);
    }
    SendResponse(targetUrl, args);
