            int index = -1;
            bool found = false;
            foreach (DataRow dr in myDataSet.Tables[0].Rows)
            {
                index++;
                string d = dr["location"].ToString();
                if (dr[0].ToString() == txtbox1,Text)
                {
                    found=true;
                    break;
                }
            }
            if(found)
            {
                scnDataGrd.Select(index);
                scnDataGrd.SelectionBackColor = Color.Blue;
            }
