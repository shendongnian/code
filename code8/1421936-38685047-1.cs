    var startParam = cmd.Parameters.Add("@startdate", SqlDbType.DateTime2);
    var endParam = cmd.Parameters.Add("@enddate", SqlDbType.DateTime2);
    var semParam = cmd.Parameters.Add("@sem", SqlDbType.Int);
                
    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        startParam.Value = Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value);
        endParam.Value = Convert.ToDateTime(dataGridView1.Rows[i].Cells[2].Value);
        semParam.Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
        cmd.ExecuteNonQuery();
    }
