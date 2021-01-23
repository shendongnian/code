    private String activeTeam = null;
    private void frmScoreBoard_KeyUp(object sender, KeyEventArgs e) {
    
       // If the user used team selection keys
       if ((e.KeyCode == Keys.A) || (e.KeyCode == Keys.B) || (e.KeyCode == Keys.C)) {
          // Select the team according to pressed key
          ActivateTeamForScoring(e);
          // Return as we don't need to do anything else on this keystroke
          return;
       }
       // If the user came here by pressing the scoring keys
       else {
          // If a team wasn't set, return
          if (activeTeam == null) { return; }
          // Resolve the score according to pressed key
          int? score = ResolveScore(e);
          // If the user pressed correct score key, update
          if (score != null) {
             // Perform the score update to database
             UpdateTeamScore(activeTeam, score.Value);
          }
          // Reset active team after scoring
          activeTeam = null;
       }
    }
    private void ActivateTeamForScoring(KeyEventArgs e) {
       // Set the right team to be scored
       if (e.KeyCode == Keys.A) {
          activeTeam = lblScoreA;
       } else if (e.KeyCode == Keys.B) {
          activeTeam = lblScoreB;
       } else if (e.KeyCode == Keys.C) {
          activeTeam = lblScoreC;
       }
    }
    private int? ResolveScore(KeyEventArgs e) {
      if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1) {
         return 5;
      } else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2) {
         return 10;
      } else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3) {
         return 15;
      } else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4) {
         return -5;
      } else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5) {
         return -10;
      } else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6) {
         return -15;
      // If the keystroke was invalid, return null
      } else {
         return null;
      }
    }
