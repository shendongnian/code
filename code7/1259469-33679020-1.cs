        List<decimal> scoreList = new List<decimal>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimalnum;
            if (decimal.TryParse(txtScore.Text, out num))
            {
                scoreList.Add(num);
            }
            // Assign to count label Text property = scoreList.Count;
            // Assign to average label Text property = scoreList.Average();
        }
