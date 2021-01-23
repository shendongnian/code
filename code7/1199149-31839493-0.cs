     var sql = (from CLD in db.CLD
                       join AnswerComment in db.AnswerComment
                           on CLD.Id equals AnswerComment.IdCLD
                       join ListDef in db.ListDef
                           on CLD.IdListDef equals ListDef.Id
                       where ListDef.IdInspection == idInspec
                       group CLD by new ComentRespostaLFDModels
                       {
                           IdComment = CLD.Id,
                           Comment = CLD.Comments
                       } into coments
                       select new ComentRespostaLFDModels
                       {
                           IdComment = coments.Key.IdComment,
                           Comment = coments.Key.Comment,
                           StatusDifference = coment.Min() != coment.Max() //if you want to return bool or coment.Min() != coment.Max() ? 1 : 0 if you want to return int
                       }).ToList();
