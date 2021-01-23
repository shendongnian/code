    private void DrawLines()
    {
        List<MyLine> listMyLines = new  List<MyLine>();
        listMyLines.Add(new MyLine{StartPoint = new Point(0, 100), EndPoint = new Point(334, 100)});       
        for (int i = 0; i < listMyLines.Count; i++)
        {
             listMyLines[i].DrawLine();
        }
    }
