        List<int> intScoreList = new List<int>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(txtScore.Text, out num))
            {
                intScoreList.Add(num);
            }
            // Assign to count label Text property = intScoreList.Count;
            // Assign to average label Text property = intScoreList.Average();
        }
