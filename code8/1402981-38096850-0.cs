    string originalPath = "Url1234.pdf";
    string dir = Path.GetDirectoryName(originalPath);              // in this case ""
    string extension = Path.GetExtension(originalPath);            // .pdf
    string fn = Path.GetFileNameWithoutExtension(originalPath);    // Url1234
    string newFn = String.Concat(fn.Where(c => !Char.IsDigit(c))); // Url
    string newPath = Path.Combine(dir, newFn + extension);         // Url.pdf
