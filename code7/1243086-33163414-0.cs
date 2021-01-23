     private void button1_Click(object sender, EventArgs e)
        {
            if (id != "")
            {
                var papers = doc.Descendants("paper");
                foreach (var paper in papers)
                {
                    if (paper.Attribute("id").Value == id)
                    {
                        var questions = paper.Descendants("question");
                        var j = 1;
                        foreach (var question in questions)
                        {
                           GroupBox Ques&Ansoptn = new GroupBox();
                           Ques&Ansoptn.Size = new System.Drawing.Size(720, 120);
                           Ques&Ansoptn.Text = question.Attribute("ques").Value;
                           Ques&Ansoptn.Location = new Point(15, 40*j);
                           Ques&Ansoptn.Font = new Font("Microsoft Sans Serif", 10);
                            this.Controls.Add(Ques&Ansoptn);
                            var options = question.Descendants("option");
                            var i =1;
                            foreach (var option in options)
                            {
                                RadioButton rdbtn = new RadioButton();
                                rdbtn.Size = new System.Drawing.Size(400, 20);
                                rdbtn.Location = new Point(20, 20 * i);
                                rdbtn.Font = new Font("Microsoft Sans Serif", 10);
                                rdbtn.Text = option.Value;
                                Ques&Ansoptn.Controls.Add(rdbtn);
                                i++;
                            }
                            j = j+3;
                        }
                        break;
                    }
                }
            }
        }
