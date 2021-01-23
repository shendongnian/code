    TableCell tccell = item.Cells[0];
                   if (evalQuestionType == Coursewhere.BLL.Enums.EvaluationQuestionType.Label)
                        {
                            tccell.Controls[0].Visible = true;
    
                        }
                        else
                        {
                            tccell.Controls[0].Visible = false;
                       
                        }
