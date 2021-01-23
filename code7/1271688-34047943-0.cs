        const string sqlStatement = "INSERT INTO P_deasease (P_Id,Nosos,Situ,Year_d,Therapy) VALUES "; //I added the P_Id and the parameter
        int id = Convert.ToInt32(Session["pa_id"]); //I added that
        foreach (string item in sc)
        {
            if (item.Contains(","))
            {
                splitItems = item.Split(",".ToCharArray());
                sb.AppendFormat("{0}(@p_id, '{1}','{2}','{3}','{4}'); ", sqlStatement, splitItems[0], splitItems[1], splitItems[2], splitItems[3]);
            }
        }
