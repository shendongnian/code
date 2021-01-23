            //assumining the params are ints, this would be replaced with your values you want to filter with
            int[] paramValues = {100,200,300,500};
            StringBuilder sqlCommandBuilderTxt = new StringBuilder();
                    sqlCommandBuilderTxt.Append("SELECT Firstname, Lastname, Phone#, Balance FROM tblname WHERE ");
            sqlCommandBuilderTxt.Append("Balance IN (");
            SqlCommand sqlCommand = new SqlCommand();
            //loop through all the param values to build the IN statement and create the paramaters
            for (int i = 0; i < paramValues.Count(); i++)
            {
                sqlCommandBuilderTxt.Append("@balance"+i+",");
                sqlCommand.Parameters.AddWithValue("@balance" + i, paramValues[i]);
                //remove trailing , and add end ) for IN statement
                if (i == paramValues.Count() - 1)
                {
                    sqlCommandBuilderTxt.Remove(sqlCommandBuilderTxt.Length-1,1).Append(")");
                }
            }
