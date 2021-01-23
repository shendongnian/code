    var docRange = document.Content;
    bool inDelete = false;
    foreach(var para in docRange.Paragraphs)
    {
        if(para.ToString().Contains("Start flag") || inDelete)
        {
            inDelete = true;
            docRange.Delete(para);
        }
        if (para.ToString().Contains("End flag"))
        {
            // remove following line to retain this paragraph
            docRange.Delete(para);
            break;
        }
    }
