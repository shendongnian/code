    bool status = User.Identity.IsAuthenticated;
    logoutToolStripMenuItem.Enabled = status;
    changePasswordToolStripMenuItem.Enabled = status;
    masterCoaToolStripMenuItem.Enabled = status;
    generalJournalToolStripMenuItem.Enabled = status;
    loginToolStripMenuItem.Enabled = !status;
