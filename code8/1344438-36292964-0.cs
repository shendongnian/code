    string sql = string.Format(@"INSERT INTO {0}.ERSBusinessLogic VALUES ({1}, '{2}', {3}, {4}, {5}, {6}"), 
        schemaName,
        dataGridView.Rows[i].Cells["ERSBusinessLogic_ID"].Value,
        dataGridView.Rows[i].Cells["ERSBusinessLogic_Formula"].Value.ToString(),
        dataGridView.Rows[i].Cells["ERSBusinessLogic_InputsCount"].Value,
        dataGridView.Rows[i].Cells["ERSBusinessLogic_Inputs"].Value,
        convFactorIDText,
        macroIDText
        // and so forth
    );
    
