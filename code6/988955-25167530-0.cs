    public class LineSeg
    {
        Point startPoint;
        Point endPoint;
    {
    
    // vertexOfOrigin is a Point object
    
    // get every line where the point given is the starting point
    var fromVertexes = lstLineSeg.Where(line => line.endPoint == vertexOfOrigin).ToList();
    // get every line where the point given is the end point
    var toVertexes = lstLineSeg.Where(line => line.startPoint == vertexOfOrigin).ToList();
