    Dictionary<string, int> counter = new Dictionary<string, int>();
            counter.Add("counter14", 0);
            counter.Add("counter13", 0);
            counter.Add("counter12", 0);
            counter.Add("counter11", 0);
            counter.Add("counter10", 0);
            counter.Add("counter9", 4);
            counter.Add("counter8", 0);
            counter.Add("counter7", 0);
            counter.Add("counter6", 0);
            counter.Add("counter5", 4);
            counter.Add("counter4", 0);
            counter.Add("counter3", 0);
            counter.Add("counter2", 0);
            //StringBuilder sb = new StringBuilder();
            //for (int i = 14; i >= 2; i--)
            foreach(string str in counter.Keys)
            {
                //sb.Append("counter").Append(i.ToString());
                //if (sb.ToString().Contains("14")) // Problem line here
                if(counter[str]==4)
                {
                    MessageBox.Show("You have four-of-a-kind!");
                }
                //sb.Clear();
            }
