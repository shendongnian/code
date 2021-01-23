    for (int count = 0; count < countMaster; count++)
    {
        foreach (string TemplateName in TemplateList)
        {
            dt.TableName = TemplateName;
            ds.Tables.Add(dt);
   
            count++;
        }
    }
