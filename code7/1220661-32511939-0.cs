        public Response(int id, int qID)
                {
                    this.ResponseBool = new ResponseRepository().GetResponse(id).Where(m => m.QuestionID == qID).Select(m => m.ResponseBool).FirstOrDefault();
        }
        
          Answers = Questions
                         .Select(k => new Response(stepOneSaved.ApplicationID, k.QuestionID)
                        {
                            ApplicationID = stepOneSaved.ApplicationID,
                            QuestionID = k.QuestionID,
                            QuestionCategoryID = k.QuestionCategoryID,
                            QuestionText = k.QuestionText,
                        })
                        .ToList();
