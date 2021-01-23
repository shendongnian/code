    Survey
    -----------------------------------------------------
    studentID | Q1 | Q1_comments | Q2 | Q2_comments | ...
For the first question Q1, you can still use your original insert statement above:
    SqlCommand cmd = new SqlCommand("insert into Survey (Q1,Q1_Comments) values (@Q1,@Q1_Comments)", con);
    cmd.Parameters.AddWithValue("Q1", radListQ1.SelectedValue);
    cmd.Parameters.AddWithValue("Q1_Comments", txtQ1Comments.Text);
For the second question and onwards, you need to perform update instead of inserting to database. e.g.
    SqlCommand cmd = new SqlCommand("UPDATE Survey SET (Q2=@Q2,Q2_comment=@Q2_Comments)", con);
    cmd.Parameters.AddWithValue("Q2", radListQ2.SelectedValue);
    cmd.Parameters.AddWithValue("Q2_Comments", txtQ2Comments.Text);
As a little bit of advise, you might want to use transaction to do insert,update or delete, and surround them using try ... catch ...  detect/handle potential error. More reading from [MSDN][1]
