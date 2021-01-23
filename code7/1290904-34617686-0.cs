    var t = db.Tests.SingleOrDefault(x => x.ID == idFromUI);
    if(t != null){
        int? parentId = t.Parent_ID;
        int rootParentId = -1;
        while(parentId != null){
            var currentTest = db.Tests.SingleOrDefault(x => x.ID == parentId);
            if(currentTest != null){
                parentId = currentTest.Parent_ID;
                rootParentId = currentTest.ID;
            }
            else{
               parentId = null;
            }
        }
        if(rootParentId == hardcodedBusinessUnitID){
            return new TestDTO
            {
                Name = "Match Found",
                Desc = "Blah Blah"
            };
        }        
    }
    return new TestDTO
            {
                Name = string.Empty,
                Desc = "Blah Blah"
            };
