    private static int CalcColspan(XElement cell)
                {
                    if (cell.Name != W.tc)
                        return 0;
                    return cell.Element(W.tcPr).Element(W.gridSpan) == null ? 1 :
                            Convert.ToInt32(cell.Element(W.tcPr).Element(W.gridSpan).Attribute(W.val).Value);
                }
        
    private static int CalcRowspan(XElement cell)
                {
                    if (cell.Name != W.tc)
                        return 0;
                    int rowspan = 1, colNum = 0;
                    XElement currentRow = cell.Parent;
                    foreach (XElement tc in cell.NodesBeforeSelf())
                    {
                        colNum += CalcColspan(tc);
                    }
                    bool endOfSpan = false;
                    foreach (XElement row in currentRow.NodesAfterSelf())
                    {
                        int currentColNum = 0;
                        foreach (XElement tc in row.Nodes())
                        {
                            if (tc.Name != W.tc)
                                continue;
                            if (currentColNum == colNum)
                            {
                                if (tc.Element(W.tcPr).Element(W.vMerge) != null)
                                {
                                    if ((string)tc.Element(W.tcPr).Element(W.vMerge).Attribute(W.val) != "restart")
                                    {
                                        rowspan++;
                                        break;
                                    }
                                }
                                endOfSpan = true;
                            }
                            currentColNum += CalcColspan(tc);
                        }
                        if (endOfSpan)
                            break;
                    }
                    return rowspan;
                }
