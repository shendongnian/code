    public class TableDataProcessor : TableData
    {
        /*
         * a **very** simple implementation of the CSS writing-mode property:
         * https://developer.mozilla.org/en-US/docs/Web/CSS/writing-mode
         */
        bool HasWritingMode(IDictionary<string, string> attributeMap)
        {
            bool hasStyle = attributeMap.ContainsKey("style");
            return hasStyle
                    && attributeMap["style"].Split(new char[] { ';' })
                    .Where(x => x.StartsWith("writing-mode:"))
                    .Count() > 0
                ? true : false;
        }
        public override IList<IElement> End(
            IWorkerContext ctx,
            Tag tag,
            IList<IElement> currentContent)
        {
            var cells = base.End(ctx, tag, currentContent);
            var attributeMap = tag.Attributes;
            if (HasWritingMode(attributeMap))
            {
                var pdfPCell = (PdfPCell) cells[0];
                // **always** 'sideways-lr'
                pdfPCell.Rotation = 90;
            }
            return cells;
        }
    }
