        Parallel.ForEach(grds.Tables[0].Rows, (row) =>
        {
            dic.Add("userID", reader.GetValue(0).ToString());
            dic.Add("name", reader.GetValue(1).ToString());
            dic.Add("address", reader.GetValue(2).ToString());
            dic.Add("city", reader.GetValue(3).ToString());
            dic.Add("state", reader.GetValue(4).ToString());
            dic.Add("zip", reader.GetValue(5).ToString());
            dic.Add("Phone", reader.GetValue(6).ToString());
            //though realistically you should be doing something with your specific row
        });
