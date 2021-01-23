        private int calculateSum(params string[] arguments)
        {
             int sum = 0;
             try
             {
                 foreach (var arg in arguments)
                 {
                     sum += int.Parse(arg);
                 }
             }
             catch (FromatException)
             {
                 MessageBox.Show("Ooops! You entered an invalid number.");
             }
             catch (OverflowEcxeption)
             {
                 MessageBox.Show("Ooops! You entered an number that it too big.");
             }
             return arg;
        }
