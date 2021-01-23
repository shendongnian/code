    private void rtb_TextChanged(object sender, EventArgs e) {
            var cursorPosition = rtb.SelectionStart;
            rtb.SelectAll();
            rtb.SelectionColor = Color.Black;
            var partsToHighlight = Regex.Matches(rtb.Text, "{[^}{]*}")
                .Cast<Match>()
                .ToList();
            foreach (var part in partsToHighlight) {
                rtb.Select(part.Index, part.Length);
                rtb.SelectionColor = Color.Red;
            }
            rtb.Select(cursorPosition, 0);
        }
