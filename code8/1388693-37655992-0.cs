        int input = int.Parse(txt1.Text);   
         Random r = new Random();
                        List<int> sums = new List<int>();
                        if(input<=8)
                        {
                            
                            for (int i = 0; i <= 10; i++)
                            {
                                sums.Add( r.Next(input)+ r.Next(input));
                            }
     lbl1.Text = sums[0].ToString();
                        }
