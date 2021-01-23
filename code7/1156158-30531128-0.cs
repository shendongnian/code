    //load the whole file in to memory
    var lines = File.ReadAllLines("path-to-file"); //don't forget to add using System.IO;
    //you will have to fill in your specific logic
    MyCustomObject currentObject = null;
    List<MyCustomObject> objects = new List<MyCustomObject>();
    //loop over the lines in the file
    foreach(var line in lines) {
        if(line.StartsWith("------->")) {
            //header line
            
            //Again, fill in your logic here
            currentObject = new MyCustomObject();
            currentObject.SetHeader(line);
            objects.Add(currentObject);
        } else {
            //body line
            
            //double check that the file isn't malformed
            if(currentObject == null) throw new Exception("Missing header record at beginning of file!");
            
            //process the line
            currentObject.AddLine(line);
        }
    }
    //done!
