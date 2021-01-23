    var _root = "C:\\Users\\~\\DirichletProcessClustering\\Results";
    var _clusterFilename = _year.ToString() + "cluster.txt";
    var _path = Path.Combine(_root, _year.ToString());  
    
    if(!Directory.Exists(_path))
    {
       Directory.CreateDirectory(_path);
    }
    
    // output topk file
    TextWriter _twClus = File.CreateText(Path.Combine(_path, _clusterFilename));   
    foreach (// loop )  
    { 
       _twClus.WriteLine("Cluster");  
       //... rest of the implementation...
    }
  
