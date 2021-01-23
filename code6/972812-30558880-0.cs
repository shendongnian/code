    private void transparentPanel_Click(object sender, System.EventArgs e)
            {
                var mouseEventArgs = e as MouseEventArgs;
                if (mouseEventArgs.Button == MouseButtons.Left)
                {
                    // If currently in text editing mode
                    if (m_currentSelectedControl == e_SelectedControl.TEXT)
                    {
                        Point capturedPoint = new Point(mouseEventArgs.X, mouseEventArgs.Y);
                        int charIndex = richTextBox.GetCharIndexFromPosition(capturedPoint);
                        int lastChar = richTextBox.TextLength;
                        Point lastCharPoint = richTextBox.GetPositionFromCharIndex(lastChar);
    
                        if (lastCharPoint.X == capturedPoint.X ||
                            lastCharPoint.Y < capturedPoint.Y)
                        {
                            charIndex++;
                        }
    
                        richTextBox.SelectionStart = charIndex;
                        richTextBox.SelectionLength = 0;
                        richTextBox.Select();
                        transparentPanel.Refresh();
                    }
                }
            }
