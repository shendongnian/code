    var ctrls = friendRequestPanel.Controls.Cast<Control>()
                                  .Where(Convert.ToInt32(x.Tag) == idRequest)
                                  .ToList();  //<--- Creates a new List<Control>
    foreach (Control ct in ctrls)
    {
        friendRequestPanel.Controls.Remove(ct);
        ct.Dispose();
    }
