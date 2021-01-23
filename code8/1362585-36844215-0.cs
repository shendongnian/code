    SPList pageList = web.Lists["Pages"];
    SPQuery query = new SPQuery();
    query.Query = "<Where><Geq><FieldRef Name='CheckinUser' LookupId='TRUE'/><Value Type='int'>0</Value></Geq></Where>";
        foreach (SPListItem item in pageList.GetItems(query))
        {
            if (item.ContentType.Name == "Article Page")
            {
                var publishingPage = PublishingPage.GetPublishingPage(item);
            }
        }
