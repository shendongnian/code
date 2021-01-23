    private Folder ConvertHtmlHeadersToFolderStructure(XElement header, Folder containingFolder)
        {
            // Extract the usable data from the element
            // header.Value
            string title;
            // header.NextNode.ToString() for everything between this and the next header element 
            StringBuilder contentSb; 
            ExtractInfo(header, out title, out contentSb);
            // Determine if this header element is going to be a page or a folder
            // It's a page if the current header element number is greater than or equal to
            // the next header element number, e.g. h3 >= h2; h3 is a page
            XElement nextHeader;
            if (IsElementALeaf(header, out nextHeader))
            {
                containingFolder.Pages.Add(new Page
                {
                    Content = contentSb.ToString(),
                    Title = title,
                    Folder = containingFolder
                });
                if (nextHeader != null)
                {
                    int thisHeaderLevel, nextHeaderLevel;
                    GetHeaderLevel(header, nextHeader, out thisHeaderLevel, out nextHeaderLevel);
                    var upLevelFolder = containingFolder;
                    for (int i = 0; i < thisHeaderLevel - nextHeaderLevel; i++)
                    {
                        upLevelFolder = upLevelFolder.ParentFolder;
                    }
                    ConvertHtmlHeadersToFolderStructure(nextHeader, upLevelFolder);
                }
                return containingFolder;
            }
            else
            {
                var subFolder = new Folder
                {
                    Description = contentSb.ToString(),
                    Name = title,
                    ParentFolder = containingFolder
                };
                // nextHeader shouldn't be null if we got here
                subFolder = ConvertHtmlHeadersToFolderStructure(nextHeader, subFolder);
                containingFolder.Subfolders.Add(subFolder);
                return containingFolder;
            }
        }
