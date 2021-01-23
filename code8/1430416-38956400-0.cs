    private async void adjustStatsButton_Click(object sender, EventArgs e)
    {
      await Task.Run(() => ReadWrite.AdjustStats(winnerInput.Text, loserInput.Text));
      winnerInput.Text = "";
      loserInput.Text = "";
      Refresh(leaderboardBox);
    }
