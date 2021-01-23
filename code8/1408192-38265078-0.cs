            DataTable dt =new DataTable();
            char[] charac = {'A','B','C'};
            for (int k = 0; k < 3; k++)
            {
                for (int m = 0; m < 3; m++)
                {                    
                    dt.Columns.Add("Name_" + charac[k]+(m+1));
                    dt.Columns.Add("Class_" + charac[k]+(m+1));
                    dt.Columns.Add("Score_" + charac[k]+(m+1));
                }
            }
