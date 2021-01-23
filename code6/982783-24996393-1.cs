    public class SplitTableWatcher : IPdfPTableEventSplit {
        /// <summary>
        /// The current table split state
        /// </summary>
        private SplitState currentSplitState = SplitState.None;
        public void SplitTable(PdfPTable table) {
            //Disable header rows for automatic splitting (per OP's request)
            table.HeaderRows = 0;
            //We now need to split on the next page, so append the flag
            this.currentSplitState |= SplitState.DrawOnNextPage;
        }
        public void TableLayout(PdfPTable table, float[][] widths, float[] heights, int headerRows, int rowStart, PdfContentByte[] canvases) {
            //If a split happened and we're on the next page
            if (this.currentSplitState.HasFlag(SplitState.DrawOnThisPage)) {
                //Draw something, nothing too special here
                var cb = canvases[PdfPTable.TEXTCANVAS];
                cb.BeginText();
                cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false), 18);
                
                //Use the table's widths and heights to find a spot, this probably could use some tweaking
                cb.SetTextMatrix(widths[0][0], heights[0]);
                cb.ShowText("A Split Happened!");
                cb.EndText();
                //Unset the draw on this page flag, it will be reset below if needed
                this.currentSplitState ^= SplitState.DrawOnThisPage;
            }
            //If we previously had the next page flag set change it to this page
            if (currentSplitState.HasFlag(SplitState.DrawOnNextPage)) {
                this.currentSplitState = SplitState.DrawOnThisPage;
            }
        }
    }
