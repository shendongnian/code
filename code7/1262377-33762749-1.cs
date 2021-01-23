       private async void button1_Click(object sender, EventArgs e)
        {
            var answer = await FindPrimeNumberAsync(Convert.ToInt64(txtprime.Text));
            MessageBox.Show(answer.ToString());
        }
        public  Task<long> FindPrimeNumberAsync(long n)
        {
          return Task.Run<long>(()=>
           {
               int count = 0;
               long a = 2;
               while (count < n)
               {
                   long b = 2;
                   int prime = 1;// to check if found a prime
                   while (b * b <= a)
                   {
                       if (a % b == 0)
                       {
                           prime = 0;
                           break;
                       }
                       b++;
                   }
                   if (prime > 0)
                       count++;
                   a++;
               }
               return (--a);
           });
        }
