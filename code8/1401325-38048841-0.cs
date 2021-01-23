        //perform some tasks
    
        var searchResults =  ts.validateDetails(gmvi);
    
        return Ok(searchResults);
    
       }
    
       var tasks = new Task[]
            {
                Task.Factory.StartNew(() => gd.validateChapterCodeDetails(_input1)),
                Task.Factory.StartNew(() => gd.validateGroupCodeDetails(_input1)),
                Task.Factory.StartNew(() => gd.validateMasterIdDetails(_input1))
            };
    
           var things = await Task.WhenAll(tasks);
    
           //Some tasks
    
           return result;
