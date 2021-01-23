            private void button1_Click(object sender, EventArgs e)
            {
                var e1 = int.Parse(textBox1.Text);
                var e2 = int.Parse(textBox2.Text);
                var e3 = int.Parse(textBox3.Text);
    
                //Code to display winning numbers here
    
                var input = new List<int>();
                input.Add(e1);
                if (!input.Contains(e2))
                    input.Add(e2);
                if (!input.Contains(e3))
                    input.Add(e3);
    
                var lotteryNum = new Random();
    
                var randoms = new List<int>();
                randoms.Add(lotteryNum.Next(1,4));
                var rand2 = lotteryNum.Next(1, 4);
                if (!randoms.Contains(rand2))
                    randoms.Add(rand2);
                var rand3 = lotteryNum.Next(1, 4);
                if (!randoms.Contains(rand3))
                    randoms.Add(rand3);
    
                //Code to display random numbers here
    
                //Compare the two lists. Since they both have distinct values respectively no worries of duplicate matches
                var matches = 0;
                if(input.Contains(randoms[0]))
                    matches++;
                if (input.Contains(randoms[1]))
                    matches++;
                if (input.Contains(randoms[2]))
                    matches++;
    
                //Do logic for displaying matches to user
            }
