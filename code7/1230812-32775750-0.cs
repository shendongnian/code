    using System.Linq;
    var files = Directory.EnumeratedFiles(reportDirectoryName, "*.pdf", SearchOption.AllDirectories);
      .Select(n => PathGetFile(n))
      .Where(n => n.Contains(searchName);
    ListBox1.Item.Clear;
    ListBox1.Items.Add(Path.GetFileName(files));
