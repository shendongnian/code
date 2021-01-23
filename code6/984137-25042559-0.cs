    using (var fs = new FileStream(testFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
        using (var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, fs)) {
                doc.Open();
                //Number of columns to create
                var columnCount = 4;
                //Distance be columns
                var gutterWidth = 20;
                //Setup and calculate some helper variables
                //The left-most edge
                var tableLeft = doc.LeftMargin;
                //The bottom-most edge
                var tableBottom = doc.BottomMargin;
                //The available width and height of the table taking into account the document's margins
                var tableWidth = doc.PageSize.Width - (doc.LeftMargin + doc.RightMargin);
                var tableHeight = doc.PageSize.Height - (doc.TopMargin + doc.BottomMargin);
                //The width of a column taking into account the gutters (three columns have two gutters total)
                var columnWidth = (tableWidth - (gutterWidth * (columnCount - 1))) / columnCount;
                //Create an array of columns
                var columns = new List<iTextSharp.text.Rectangle>();
                //Create one rectangle per column
                for (var i = 0; i < columnCount; i++) {
                    columns.Add(new iTextSharp.text.Rectangle(
                            tableLeft + (columnWidth * i) + (gutterWidth * i),               //Left
                            tableBottom,                                                     //Bottom
                            tableLeft + (columnWidth * i) + (gutterWidth * i) + columnWidth, //Right
                            tableBottom + tableHeight                                        //Top
                            )
                       );
                }
                //Create our column text object
                var ct = new ColumnText(writer.DirectContent);
                //Create and set some placeholder copy
                for (var i = 0; i < 100; i++) {
                    ct.AddText(new Phrase(String.Format("This is cell {0}. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris lorem tortor, condimentum non urna congue, tincidunt viverra elit.", i)));
                    //Optional but helps to add spacing
                    ct.AddText(Chunk.NEWLINE);
                    ct.AddText(Chunk.NEWLINE);
                }
                //As we draw content below we'll loop through each column defined above
                //This holds the current column index that we'll change in the loop
                var currentColumnIndex = 0;
                //Current status as returned from ct.go()
                int status = 0; //START_COLUMN is defined in Java but is currently missing in .Net
                //Loop until we've drawn everything
                while (ColumnText.HasMoreText(status)) {
                    //Setup our column
                    ct.SetSimpleColumn(columns[currentColumnIndex]);
                    //To be honest, not quite sure how this is used but I think it is related to leading
                    ct.YLine = columns[currentColumnIndex].Top;
                    //This actually "draws" the text and will return either 0, NO_MORE_TEXT (1) or NO_MORE_COLUMN(2)
                    status = ct.Go();
                    //Increment our current column index
                    currentColumnIndex += 1;
                    //If we're out of columns
                    if (currentColumnIndex > (columns.Count - 1)) {
                        //Create a new page and reset to the first column
                        doc.NewPage();
                        currentColumnIndex = 0;
                    }
                }
                doc.Close();
            }
        }
    }
