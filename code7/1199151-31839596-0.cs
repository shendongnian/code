    //Get all the ListDefIds where IdInspection == 1042
    var listDefIds = db.ListDef.Where(x => x.IdInspection == 1042).Select(x => x.Id).ToList();
    
    //filter CLD list by those ListDefId's
    var filteredCLDList = db.CLD.Where(x => listDefIds.Contains(x.IdListDef)).ToList();
    
    //filter answercomments by those whose IdCLD's are in the filtered CLD list
    var filteredAnswerComments = db.AnswerComment.Where(x => filteredCLDList.Select(x => x.Id).Contains(x.IdCLD)).ToList();
    
    //assuming status diff will always be same, calculate statusDiff
    var statusDiff = filteredAnswerComments.Min(x.IdStatus) == filteredAnswerComments.Max(x.IdStatus) ? 0 : 1;
    
    //filter CLD list again by filtered answercomments, then select new objects
    var sql = filteredCLDList.Where(x => filteredAnswerComments.Select(x => x.IdCLD).Contains(x.Id))
    			.Select(x => new { Id = x.Id, Comments = x.Comments, statusDifference = statusDiff}).GroupBy(x => x.Id).ThenBy(x => x.Comments);
