    foreach (string TemplateName in TemplateList)
    {
        if (TemplateList.IndexOf(TemplateName) < countMaster)
        {
            dt.TableName = TemplateName;
            ds.Tables.Add(dt);
        }
    }
