    Size originalSize;
    String originalText;
    void CustomizeLabel_MouseEnter(object sender, EventArgs e) {
      originalSize = CustomizeLabel.Size;
      originalText = CustomizeLabel.Text;
      StringBuilder sb = new StringBuilder();
      sb.AppendLine(originalText);
      foreach (TabPage tp in tabControl1.TabPages) {
        sb.AppendLine("    " + tp.Text);
      }
      CustomizeLabel.Text = sb.ToString();
      CustomizeLabel.Height = TextRenderer.MeasureText(CustomizeLabel.Text,
                                                       CustomizeLabel.Font).Height;
    }
    void CustomizeLabel_MouseLeave(object sender, EventArgs e) {
      CustomizeLabel.Text = originalText;
      CustomizeLabel.Size = originalSize;
    }
