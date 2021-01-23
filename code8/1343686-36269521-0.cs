    private FixedDocument ConvertToDoc(DocInfo pageData)
        {
            FixedDocument fixedDoc = new FixedDocument();
            PageContent content = new PageContent();
            FixedPage page = new FixedPage();
            DocTemplate printTemplate = new DocTemplate(pageData);
            page.Children.Add(printTemplate);
            ((System.Windows.Markup.IAddChild)content).AddChild(page);
            fixedDoc.Pages.Add(content);
            return fixedDoc;
        }
