    string strSql = @"SELECT CAST(ID as VarChar(50)) ID, Aggregation, DateDerniereSolution, DateDescription, DerniereSolution, DescriptionDemande, FileDeTraitement, NomContact, Numero, SousRubrique, TitreDemande
    FROM cfao_DigiHelp_index.DigiHelpData";
    if (CheckboxID.Items.Cast<ListItem>().Any(x => x.Selected))
    {
        List<string> conditionList = CheckboxID.Items.Cast<ListItem>().Where(x => x.Selected).Select(item => " SousRubrique Like '%" + item.Value + "%' ").ToList();
        strSql += " WHERE (" + string.Join(" OR ", conditionList) + "  )";
    }
