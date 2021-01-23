    while (dr.Read())
    {
        if ((string)dr["type"] == "SingleAnswer")
        {
            RadioButton rAnswer1 = new RadioButton();
            rAnswer1.ID = "rbl_Answer" + dr["AnswerID1"].ToString();
