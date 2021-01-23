            System.Data.SqlClient.SqlCommand sqlcmd = new System.Data.SqlClient.SqlCommand("select * from indexinfo", sqlc);
            sqlc.Open();
            System.Data.SqlClient.SqlDataReader dr = sqlcmd.ExecuteReader();
            if (dr.Read())
            { %>
           <div class="<% Response.Write(dr["classs"]); %>">
               <img src="../images/<% Response.Write(dr["img"]); %>" alt="Alternate Text" /><% Response.Write(dr["onvan"]); %>
            <div style=" height:25px"></div>
            <div class="column-center-text bounceIn animated">
               <% Response.Write(dr["matn"]); %>
            </div>
            <div><a href="#" class="btn">بیشتر بدانید</a></div>
        </div>
<%
            }%> 
