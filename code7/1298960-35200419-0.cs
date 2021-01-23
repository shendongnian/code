    public void ItemUpdatedHandler(ClientContext clientContext, Guid listId, int listItemId, ContextInfo logContext) {
        ListItem item = list.GetItemById(listItemId);
        clientContext.Load(item, i => i["PublishingPageLayout"], i => i.DisplayName);
        clientContext.ExecuteQuery();
        FieldUrlValue fuv = (FieldUrlValue)item["PublishingPageLayout"];
    }
