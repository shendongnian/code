    public List<AnswerRow> makeAnswers(string c, string r)
    {
       var result = new List<AnswerRow>();
       for(var i=0; i<r.Length; i++)
       {
           result.Add(
            new AnswerRow { Correct = c!=null?new Nullable<bool>(c[i]=='1'):null,
                     Response = r[i]=='1'
            });
       }
       return result;
    }    
