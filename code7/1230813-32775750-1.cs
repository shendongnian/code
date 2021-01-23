    using System.Linq;
    string reportDirectoryName = "..."; // fill in with full path
    string searchName = TextBox1.Text;
    if (string.IsNullOrWhitespace(searchName))
      return ...;
    var files = Directory.EnumerateFiles(reportDirectoryName, "*.pdf", SearchOption.AllDirectories);
      .Select(n => Path.GetFileName(n))
      .Where(n => n.Contains(searchName);
    ListBox1.Items.Clear();
    ListBox1.Items.Add(files);
