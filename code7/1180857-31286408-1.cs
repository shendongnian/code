            int rollNumber = 1;
            string filterExpression = string.Format("RollNo = {0}", rollNumber);
            DataRow[] rows = dt.Select(filterExpression);
            if (rows != null && rows.Length > 0)
            {
                //Exists
            }
            else
            {
                //Does not exists
            }
