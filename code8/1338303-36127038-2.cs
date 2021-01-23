    public void ActivateCurrentProblem(int i){
              Textbox problem =  Controls.Find("problem" + i, true);
              Textbox answer =  Controls.Find("answer" + i, true);
              CheckBox c =  Controls.Find("c" + i, true);
              problem.Text =(num1 + sign + num2).ToString();
              problem.Visible=true;
              answer.Visible=true;
             if (answer.Text == hiddenAnswerLabel.Text)
             { 
                 c.Checked = true; 
                 addOne();
             }
             t = int.Parse(hiddenCurrentLabel.Text); chooseRandoms(t); 
         }
