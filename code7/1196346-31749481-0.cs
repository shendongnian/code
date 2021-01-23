            bool isTaken = false;
            using (SqlConnection conn = new SqlConnection(""))
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE ClaimList set Status=@f1, ClaimedBy=@f2, ClaimedDate=@f3 where ID=@f4 AND Status <> 2", conn);
                conn.Open();
                cmd.Parameters.Add("@f1", SqlDbType.Int).Value = 2;
                cmd.Parameters.Add("@f2", SqlDbType.Int).Value = logon_user;
                cmd.Parameters.Add("@f3", SqlDbType.DateTime).Value = DateTime.Now.ToString();
                cmd.Parameters.Add("@f4", SqlDbType.Int).Value = currentID;
                if (cmd.ExecuteNonQuery() == 0)
                     isTaken = true;
            }
            
            if (!isTaken)
                 Response.Redirect("View.aspx?id=" + currentID);
            else
                 Response.Redirect("Location.aspx?lid=" + location + "&action=taken");
