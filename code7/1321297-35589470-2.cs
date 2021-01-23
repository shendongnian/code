    private void test_MouseMove(object snd, MouseEventArgs e) {
        var p = fctb.PointToPosition(fctb.PointToClient(Windows.Forms.Cursor.Position));
        // display letter
        var ch = "";
        if (p < fctb.Text.Length) {
            ch = fctb.Text[p].ToString();
        }
        Label1.Text = ch;
        // display word
        Label2.Text = GetWord(fctb, p);
    }
    private string GetWord(FastColoredTextBoxNS.FastColoredTextBox ct, int p) {
        var sb = new StringBuilder(ct.Text);
        if (sb.Length == 0 || p == sb.Length) return "";
        if (!Regex.IsMatch(sb[p].ToString(), @"^\w$")) return sb[p].ToString();
        var n1 = p;
        while (n1 > 0 && Regex.IsMatch(sb[n1 - 1].ToString(), @"^\w$")) {
            n1 -= 1;
        }
        var n2 = p;
        while (n2 < sb.Length && Regex.IsMatch(sb[n2 + 1].ToString(), @"^\w$")) {
            n2 += 1;
        }
        return sb.ToString().Substring(n1, n2 - n1 + 1);
    }
