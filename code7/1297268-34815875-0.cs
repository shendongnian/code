    while((line = sr.ReadLine))!= null){
        if(req.Success){
             Math req = request.Match(line);
             if(line.contains("<?xml")){
                  stirng s = line.Substring(line.IndexOf(@"<?xml"));
             }
        }
    }
