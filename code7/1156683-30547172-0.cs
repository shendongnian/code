    string catA = "SELECT id,fees_name,amount,fee_category FROM fees_structure where fee_category='A' ORDER BY id";
    using (SqlCommand scom = new SqlCommand(catA, con))
    {
        using (SqlDataReader read = scom.ExecuteReader())
        {
            while (read.Read())
            {
                feestableA.Append("<tr>");
                feestableA.Append("<td>" + read["fees_name"] + "</td>");
                feestableA.Append("<td>" + read["amount"] + "</td>");
                feestableA.Append("</tr>");
            }
    
            plcfeesA.Controls.Add(new Literal { Text = feestableA.ToString() });
        }
    }
}
