    List<GlueLine> SortedList;
    List<GlueLine> DrawLines = new List<GlueLine>();
    SortedList = a_listGlueLines.OrderBy(o => Math.Round(o.StartPosition.X,2)).ToList();
    foreach(GlueLine current in SortedList){
        Boolean found = false;
        foreach(GlueLine anyLine in DrawLines){
            if(current.StartPosition.Y == anyLine.StartPosition.Y){
                found = true;
                break;
            }
        }
        if(!found){
            DrawLines.Add(current);
        }
    }
