    private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
    {
        int sIndex = lstResults.SelectedIndex + 1;
        int count = lstResults.Items.Count;
        this.statusCount.Text = String.Format("{0} / {1}", sIndex, count);
        string selection = lstResults.Text;
    if (sIndex > 0)
        {
            int value = Hoot.ValueCalc.getValue(selection);
            double probable = Hoot.Probability.getProbable(selection);
            int relativeProbable = Hoot.Probability.getRelProbable(selection);
            this.statusWordStats.Text = String.Format("Raw Score: {0}   Probability: {1} (RP: {2})",
                value, probable.ToString("F4"), relativeProbable.ToString());
        }
    }
