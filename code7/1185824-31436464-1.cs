    // using System.IO;
    // using System.Windows.Forms;
    // using System.Collections.Generics;
    // using System.Linq;
    IEnumerable<string> notFound = neededFiles.Where(f => !File.Exists(f));
    if (notFound.Any())
        MessageBox.Show(
            string.Format(notFound.Count() > 1 ?
                "App can't find these files - {0}" :
                "App can't find this file - {0}",
            string.Join(", ", notFound)));
