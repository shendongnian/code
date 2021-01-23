    //Use ACE OleDb if xlsx extention
            else if (extension.Equals(".xlsx", StringComparison.CurrentCultureIgnoreCase))
            {
                constr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;IMEX=1;HDR=YES\"", FilePath);
            }
