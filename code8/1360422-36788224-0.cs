    FileStream input1 = File.OpenRead("input1.pdf");
    PdfFile file1 = new PdfFile(input1);
    PdfPageContent[] fileContent1 = file1.ExtractPageContent(0, file1.PageCount - 1);
    file1 = null;
    input1.Close();
    FileStream input2 = File.OpenRead("input2.pdf");
    PdfFile file2 = new PdfFile(input2);
    PdfPageContent[] fileContent2 = file2.ExtractPageContent(0, file2.PageCount - 1);
    file2 = null;
    input2.Close();
    PdfFixedDocument document = new PdfFixedDocument();
    int maxPageCount = Math.Max(fileContent1.Length, fileContent2.Length);
    for (int i = 0; i < maxPageCount; i++)
    {
        PdfPage page = document.Pages.Add();
        // Make the destination page landscape so that 2 portrait pages fit side by side
        page.Rotation = 90;
        if (i < fileContent1.Length)
        {
            // Draw the first file in the first half of the page
            page.Graphics.DrawFormXObject(fileContent1[i], 0, 0, page.Width / 2, page.Height);
        }
        if (i < fileContent2.Length)
        {
            // Draw the second file in the second half (x coordinate is half page) of the page
            page.Graphics.DrawFormXObject(fileContent2[i], page.Width / 2, 0, page.Width / 2, page.Height);
        }
    }
    document.Save("SideBySide.pdf");
