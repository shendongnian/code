    private void button1_Click(object sender, EventArgs e)
    {
        var grouped = MyBugList.GroupBy(b => b.State).
            Select(stateGrp => stateGrp.GroupBy(b => b.Severity));
        dataGridView1.Columns.Add("State", "State");
        foreach (var strSeverity in MyBugList.Select(b => b.Severity).Distinct())
            dataGridView1.Columns.Add(strSeverity, strSeverity);
        foreach (var state in grouped)
        {
            int nRow = dataGridView1.Rows.Add();
            dataGridView1.Rows[nRow].Cells[0].Value = state.First().First().State;
            foreach (var severity in state)
            {
                dataGridView1.Rows[nRow].Cells[severity.Key].Value = severity.Count();
            }
        }
    }
