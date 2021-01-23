    var sql = (from CLD in db.CLD
               join AnswerComment in db.AnswerComment on CLD.Id equals AnswerComment.IdCLD
               join ListDef in db.ListDef on CLD.IdListDef equals ListDef.Id
               where ListDef.IdInspection == idInspec
               group new { CLD, AnswerComment } by new ComentRespostaLFDModels
               {
                   IdComment = CLD.Id,
                   Comment = CLD.Comments
               } into coments
               select new ComentRespostaLFDModels
               {
                   IdComment = coments.Key.IdComment,
                   Comment = coments.Key.Comment,
                   StatusDifference = comments.Min(c=>c.AnswerComment.IdStatus) != comments.Max(c=>c.AnswerComment.IdStatus) ? 1 : 0
               }).ToList();
