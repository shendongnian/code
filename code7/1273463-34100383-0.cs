    private string ConStr = WebConfigurationManager.ConnectionString["ConnectionStringName"].ConnectionString;
    private SqlConnection connection = new SqlConnection(ConStr);
    private static void onlyID(ListBox id) //if control with ID "id" is ListBox, or change to another. You didn't post design page, that's why I just think
    {
        try{
            connection.Open();
            SqlCommand command = new SqlCommand("select id from appointment");
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read() && reader.HasRows)
            {
                id.Add(reader.GetInt64(0));
            }
        }
        catch(Exception ex){
            //If some exception will occur
        }
        finally{
            connection.Close();
            Response.Redirect("update-appointment.aspx");
        }
    }
    public static void fetchData(ContentPlaceHolder PlaceHolder1)
    {
        StringBuilder html = new StringBuilder();
        using (SqlCommand command = new SqlCommand())
        {
            command.Connection = connection;
            //command.CommandType = CommandType.Text;
            command.CommandText = "select * from appointment";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            html.Append("<table border='2' width='1100'  style='color:white'>");
            html.Append("<tr align='center'>" +
                        "<td style='font-size:25px'>Column 1</td>" +
                        "<td style='font-size:25px'>Column 2</td>" +
                        "<td style='font-size:25px'>Column 3</td>" +
                        "<td style='font-size:25px'>Column 4</td>" +
                        "<td style='font-size:25px'>Column 5</td>" +
                        "<td style='font-size:25px'>Column 6</td>" +
                        "<td style='font-size:25px'>Column 7</td>" +
                        "<td style='font-size:25px'>Column 8</td>" +
            "</tr>");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    html.Append("<tr align='center'>");
                    html.Append("<td>" + reader[0] + "</td>");
                    html.Append("<td>" + reader[1] + "</td>");
                    html.Append("<td>" + reader[2] + "</td>");
                    html.Append("<td>" + reader[3] + "</td>");
                    html.Append("<td>" + reader[4] + "</td>");
                    html.Append("<td>" + reader[5] + "</td>");
                    html.Append("<td>" + reader[6] + "</td>");
                    html.Append("<td>" + "<a href='update-appointment.aspx?id=" + reader[0] + "'><img src='../images/edit.png' style='height:25px;' /></a>" + " " + "<a href='delete-appointment.aspx?id="+reader[0]+"'><img src='../images/del.png' style='height:25px;' /></a>");
                    html.Append("</tr>");
                }
                html.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            }
        }
    }
