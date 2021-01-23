    // Get the column values for each member as an array.
    var rows = list
        .GroupBy(x => x.MemberID)
        .Select(x => {
            var memberCols = new object[] { x.Key, x.First().Username };
            var answerCols = questions.Select(q => x.Where(a => a.QuestionID == q.Id).Select(a => a.Answer).FirstOrDefault());
            return memberCols.Concat(answerCols).ToArray();
        });
