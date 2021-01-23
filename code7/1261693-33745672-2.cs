    catch (SqlException sex)
    {
        for (int i = 0; i < sex.Errors.Count; i++)
        {
            String sexDetail = String.Format("SQL Exception #{0}{1}Source: {2}{1}Number: {3}{1}State: {4}{1}Class: {5}{1}Server: {6}{1}Message: {7}{1}Procedure: {8}{1}LineNumber: {9}",
                i+1, // Users would get the fantods if they saw #0 
                Environment.NewLine, 
                sex.Errors[i].Source, 
                sex.Errors[i].Number, 
                sex.Errors[i].State, 
                sex.Errors[i].Class, 
                sex.Errors[i].Server, 
                sex.Errors[i].Message, 
                sex.Errors[i].Procedure, 
                sex.Errors[i].LineNumber);
            MessageBox.Show(sexDetail);
        }
    }
    catch (Exception ex)
    {
        String exDetail = String.Format(UsageRptConstsAndUtils.ExceptionFormatString, ex.Message, Environment.NewLine, ex.Source, ex.StackTrace);
        MessageBox.Show(exDetail);
    }
