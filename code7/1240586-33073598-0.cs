        private void Form1_Load(object sender, EventArgs e)
        {
            this.Primes.CheckedChanged += Options_CheckedChanged;
            this.Evens.CheckedChanged += Options_CheckedChanged;
            this.Odds.CheckedChanged += Options_CheckedChanged;
            this.Min.TextChanged += Range_Changed;
            this.Max.TextChanged += Range_Changed;
            CheckNumbers();
        }
        private void Range_Changed(object sender, EventArgs e)
        {
            CheckNumbers();
        }
        private void Options_CheckedChanged(object sender, EventArgs e)
        {
            CheckNumbers();
        }
        private void CheckNumbers()
        {
            int min, max;
            try
            {
                min = Convert.ToInt32(Min.Text);
                max = Convert.ToInt32(Max.Text);
            }
            catch (Exception)
            {
                Results.Text = "Invalid Range!";
                return;
            }
            
            List<int> lstPrimes = new List<int>();
            List<int> lstEvens = new List<int>();
            List<int> lstOdds = new List<int>();
            if (Primes.Checked || Evens.Checked || Odds.Checked)
            {
                bool isPrime;
                for (int f = min; f <= max; f++)
                {
                    if (Primes.Checked)
                    {
                        isPrime = true;
                        for (int j = 2; j <= max; j++)
                        {
                            if (f != j && f % j == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                        if (isPrime)
                        {
                            lstPrimes.Add(f);
                        }
                    }
                    int modResult = f % 2;
                    if (Evens.Checked && modResult == 0)
                    {
                        lstEvens.Add(f);
                    }
                    if (Odds.Checked && modResult != 0)
                    {
                        lstOdds.Add(f);
                    }
                }
            }
            
            StringBuilder sb = new StringBuilder();
            if (Primes.Checked)
            {
                sb.AppendLine("The Prime Numbers Are:" + String.Join(",", lstPrimes));
            }
            if (Evens.Checked)
            {
                sb.AppendLine("The Even Numbers Are:" + String.Join(",", lstEvens));
            }
            if (Odds.Checked)
            {
                sb.AppendLine("The Odd Numbers Are:" + String.Join(",", lstOdds));
            }
            Results.Text = sb.ToString();
        }
