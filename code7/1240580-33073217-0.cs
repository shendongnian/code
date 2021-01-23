        private void Primes_CheckedChanged(object sender, EventArgs e)
        {
            {
                string final = "The Prime Numbers Are:";// you need to keep the result out of the loop instead of reset it everytime
                int f = Convert.ToInt32(Min.Text);
                int i = Convert.ToInt32(Max.Text);
                bool isPrime = true;
                for (f = 0; f <= i; f++)
                {
                    for (int j = 2; j <= i; j++)
                    {
                        if (f != j && f % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        final = final + " " + f;// then add your found number to the result here
                        Result.Text = final;
                    }
                    isPrime = true;
                }
            }
        }
