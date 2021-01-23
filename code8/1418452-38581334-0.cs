    string test = string.Format("Q" + answerVM.qCounter);                    
                    string questionAns = (answerVM.Question + " - " + answerVM.NoComment);
    
                    AnswerSheet answer= db.AnswerSheets.Find(answerVM.ID);
                    if (answer== null)
                    {
                        return HttpNotFound();
                    }                
                    answer.GetType().GetProperty(test).SetValue(answer, questionAns, null);
    db.Entry(answer).State = EntityState.Modified;
                    db.SaveChanges();
