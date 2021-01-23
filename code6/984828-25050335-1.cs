    FlowLayoutPanel flp = new FlowLayoutPanel();
    Label lblA = new Label();
    lblA.Text = "Hi ";
    flp.Controls.Add(lblA);
    Label lblB = new Label();
    lblB.Text = m_senior;
    lblB.ForeColor = Color.Red;
    flp.Controls.Add(lblB);
    Label lblC = new Label();
    lblC.Text = " and "; // The spaces for this and "Hi " may or may not be necessary. They are in theory, but it's mostly dependent on the margins of the Labels. Just check which looks best.
    flp.Controls.Add(lblC);
    Label lblD = new Label();
    lblD.Text = m_pwd;
    lblD.ForeColor = Color.Red;
    flp.Controls.Add(lblD);
