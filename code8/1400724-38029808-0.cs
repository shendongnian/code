    var rankResult = rank.ToList(); // Or int[] rankResult = rank.ToArray<int>();
    for (int ii = 0; ii < rankResult.Length; ii++)
    {
         string empNumb = dataGridView1[dataGridView1.Columns["empNumb"].Index, ii].Value.ToString();
         RC.updateRank(rankResult[ii], empNumb, period, year);
    }
