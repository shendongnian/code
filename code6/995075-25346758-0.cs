            public string sortParity()
               {
                  string userInput = TextBox1.Text;
                  string[] numberArray = userInput.Split(',');
                  foreach (string i in numberArray)
                  {
                   int x = Int32.Parse(i);
                     if (x % 2 == 0){
                   ListBox1.Items.Add(x);
                 } 
                    else {
               ListBox2.Items.Add(x);
            }
              }
          }
