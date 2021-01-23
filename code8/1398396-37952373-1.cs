    private void Reject_Click(object sender, EventArgs e)
    {
        Button c = sender as Button;
        int idRequest = Convert.ToInt32(c.Tag);
        var ctrls = friendRequestPanel.Controls
                                      .Cast<Control>
                                      .Where(x => x.Tag != null &&
                                             Convert.ToIn32(x.Tag) == idRequest);
        foreach(Control ct in ctrls)
        {
              friendRequestPanel.Controls.Remove(ct);
              ct.Dispose();
        }
        updateFriendRequestDatabase(2);
    }
