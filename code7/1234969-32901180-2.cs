        // find the table cell containing the search string in the copied table
        var targetCell = tableCopy.Descendants<Text>()
                                  .First(t => t.InnerText == searchString)
                                  .Ancestors<TableCell>()
                                  .First();
        // get the properties from the first paragraph in the target cell (so we can copy them)
        var paraProps = targetCell.Descendants<ParagraphProperties>().First();
        // now add new stuff to the target cell
        List<string> stuffToAdd = new List<string> { "foo", "bar", "baz", "quux" };
        foreach (string item in stuffToAdd)
        {
            // for each item, clone the paragraph properties, then add a new paragraph
            var propsCopy = (ParagraphProperties)paraProps.CloneNode(deep: true);
            targetCell.AppendChild(new Paragraph(propsCopy, new Run(new Text(item))));
        }
