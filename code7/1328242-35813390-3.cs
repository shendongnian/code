    List<int> counter = new List<int>();
            counter.Add(0);
            counter.Add(0);
            counter.Add(0);
            counter.Add(4);
            counter.Add(0);
            counter.Add(0);
            counter.Add(0);
            counter.Add(4);
            counter.Add(0);
            //for (int i = 14; i >= 2; i--)
            foreach(int value in counter)
            {
                //sb.Append("counter").Append(i.ToString());
                //if (sb.ToString().Contains("14")) // Problem line here
                if(value==4)
                {
                    MessageBox.Show("You have four-of-a-kind!");
                }
                //sb.Clear();
            }
