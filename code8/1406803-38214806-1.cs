    //using System.Text.RegularExpressions;
    string input = this.textBox1.Text;
    var parts = Regex.Matches(input, @"[\""].+?[\""]|[^ ]+")
                     .Cast<Match>()
                     .Select(x => x.Value)
                     .ToList();
    parts.ForEach(x => MessageBox.Show(x.Trim('"')));
