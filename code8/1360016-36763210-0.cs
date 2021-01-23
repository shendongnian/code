    private void btn1_Click(object sender, EventArgs e)
    {
     // Add a new row
      this.Controls.Add(new LiteralControl("<tr>"));
      this.Controls.Add(new LiteralControl("<td width='100' >"));
      this.Controls.Add(txt21);
      this.Controls.Add(new LiteralControl("</td>"));
      this.Controls.Add(new LiteralControl("<td width='100'>"));
      this.Controls.Add(dt21);
      this.Controls.Add(new LiteralControl("</td>"));
      this.Controls.Add(new LiteralControl("<td width='100'>"));
      this.Controls.Add(dt22);
      this.Controls.Add(new LiteralControl("</td>"));
      this.Controls.Add(new LiteralControl("<td width='100'>"));
      this.Controls.Add(txt22);
      this.Controls.Add(new LiteralControl("</td>"));
      this.Controls.Add(new LiteralControl("<td width='100'>"));
      this.Controls.Add(txt23);
      this.Controls.Add(new LiteralControl("</td>"));
      this.Controls.Add(new LiteralControl("<td width='100'>"));
      this.Controls.Add(btn2);
      this.Controls.Add(new LiteralControl("</td>"));
      this.Controls.Add(new LiteralControl("</tr>"));
    }
