    Size szText;
    using (Graphics g = textBox1.CreateGraphics())
    {
        szText = TextRenderer.MeasureText(g,
                                          textBox1.Text,
                                          textBox1.Font,
                                          textBox1.ClientSize,
                                          TextFormatFlags.Left
                                            | TextFormatFlags.Top
                                            | TextFormatFlags.NoPrefix
                                            | TextFormatFlags.TextBoxControl);
    }
