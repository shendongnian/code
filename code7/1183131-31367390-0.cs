           private void button1_Click(object sender, EventArgs e)
        {
            var list = (from c in Session.DB.PoolUsers
                     select c).ToList();
            int questionId = Convert.ToInt32(textBox1.Text);
            var questionAnswers = list.Where(elem => elem.PoolQID == questionId);
            int questionAnswersCount = questionAnswers.Count();
            var answersPrecentage = questionAnswers
                                    .GroupBy(elem => elem.PoolAID)
                                    .ToDictionary(grp => grp.Key, grp => (grp.Count() * 100.0 / questionAnswersCount));
            dataGridView1.DataSource = answersPrecentage.ToArray();
            //Draw Chart From DataGridview:
            chart1.DataBindTable(answersPrecentage);
          
        }
