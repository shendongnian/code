    protected void Page_Load(object sender, EventArgs e)
    {
    }
    [WebMethod]
    public static List<string> GetAutoCompleteData(string value, string filterBy)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            con.Open();
			string command = string.Format("select {0} from Users where {0} LIKE '%'+@SearchText+'%'", filterBy);
			using (SqlCommand cmd = new SqlCommand(command, con))
			{
				cmd.Parameters.AddWithValue("@SearchText", value);
				using (SqlDataReader dr = cmd.ExecuteReader())
				{
                    List<string> result = new List<string>();
					while (dr.Read())
					{
						result.Add(dr.GetString(0));
					}
					return result;
				}
			}
        }
    }
    <script type="text/javascript">
        $(document).ready(function (e) {
            $('.search-panel .dropdown-menu').find('a').click(function (e) {
                e.preventDefault();
                var concept = $(this).text();
                $('#search_concept').text(concept);
            });
        });
    </script>
