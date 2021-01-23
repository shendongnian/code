    StringBuilder sb = new StringBuilder();
    sb.Append("x:");
    sb.Append(node_.CubeNode.BoundingBox.Mix.X);
    sb.Append("y:");
    sb.Append(node_.CubeNode.BoundingBox.Min.Y);
    sb.Append("z:");
    sb.Append(node_.CubeNode.BoundingBox.Mix.Z);
    string posMin = sb.ToString();
    
    sb.Clear();
    // do the same for posMax    
