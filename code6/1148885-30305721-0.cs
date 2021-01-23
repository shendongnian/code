    private void GameEndTimer_Tick(object sender, EventArgs e)
    {
        this.Visible = false;
        EndGameForm gform = new EndGameForm(this._tobeSentAsArgument);
        gform.Show();
        GameEndTimer.Enabled = false;
        var frm2 = new EndGameForm(ScoreLabel.Text.ToString());
        frm2.Show();
    }
