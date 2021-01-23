    public static IEnumerable<Line> GetLines()
    {
        var returnData = new List<Line>();
        try
        {
            using (var conn = new SqlConnection("blahblahblah; "))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM Line", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                // string s = (reader["ID"].ToString());
                                int x1 = Convert.ToInt32(reader["x1"]);
                                int x2 = Convert.ToInt32(reader["x2"]);
                                int y1 = Convert.ToInt32(reader["y1"]);
                                int y2 = Convert.ToInt32(reader["y2"]);
                                returnData.Add(new Line()
                                {
                                    Pt1 = new Point(x1, y1),
                                    Pt2 = new Point(x2, y2),
                                    PenWidth = Convert.ToInt32(reader["Width"]),
                                    PenColor = Color.FromArgb(Convert.ToInt32(reader["Color"]))
                                });
                            }
                        }
                    }
                }
                conn.Close();
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
            // MessageBox.Show(PenColor.ToString());
            // MessageBox.Show(PenWidth.ToString());
        }
        return returnData;
    }
