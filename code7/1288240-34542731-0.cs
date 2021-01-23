    foreach (var rendering in renderings)
    {
        if (rendering.Placeholder == "headerPlaceholder")
            headerRenderingDatasourceId = rendering.Settings.Datasource;
        else if (rendering.Placeholder == "/aboutSectionPlaceholder/textPlaceholder")
            aboutRenderingDatasourceId = rendering.Settings.Datasource;
    }
    Item headerRenderingDatasourceItem;
    if (!string.IsNullOrEmpty(headerRenderingDatasourceId)
        headerRenderingDatasourceItem = item.Database.GetItem(headerRenderingDatasourceId);
