    int LeftWidth = 2000;
    int RightWidth = 2000;
    int NumberOfCols = 2;
    Table leftTable = StartTable(NumberOfCols, LeftWidth); // Create a basic table
    Table rightTable = StartTable(NumberOfCols, RightWidth);
    
    /// Add table position properties and place table in top left
    TableProperties tblProps = leftTable.Descendants<TableProperties>().First();
    TablePositionProperties tblPos = new TablePositionProperties() { VerticalAnchor = VerticalAnchorValues.Text, TablePositionY = 1 };
    TableOverlap overlap = new TableOverlap() { Val = TableOverlapValues.Overlap };
    tblProps.Append(tblPos, overlap);
    body.Append(leftTable);
    
    /// Add position property to right table, set 8700 and 2400 to where you want the table
    TableProperties tblProps2 = rightTable.Descendants<TableProperties>().First();
    TablePositionProperties tblPos2 = new TablePositionProperties() { HorizontalAnchor = HorizontalAnchorValues.Page, VerticalAnchor = VerticalAnchorValues.Page, TablePositionX = 8700, TablePositionY = 2400 };
    TableOverlap overlap2 = new TableOverlap() { Val = TableOverlapValues.Overlap };
    tblProps2.Append(tblPos2, overlap2);
    body.Append(rightTable);
