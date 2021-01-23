    private List<String> _duckbillsList;
    . . .
    private void LoadduckbillstringList()
    {
        if (null == _duckbillsList)
        {
            _duckbillsList = new List<string>();
        }
        using (SqlConnection con = new SqlConnection(PlatypusConstsAndUtils.CPSConnStr))
        {
            using (SqlCommand cmd = new SqlCommand(PlatypusConstsAndUtils.SelectPlatypusIdOnlyQuery, con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    _duckbillsList = dt.AsEnumerable()
                       .Select(p => p.Field<string>("platypusId"))
                       .ToList();
                }
            }
        }
    }
    labelFirstPlatypus.Text = _duckbillsList[0].ToString();
