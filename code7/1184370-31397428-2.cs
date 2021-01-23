    static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter numbers (Example 25,46,19)");
                var input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Your input is wrong");
                    return;
                }
                var numbers = input.Split(',');
                //Sort by descending order
                for (int i = 0; i < numbers.Length; i++)
                {
                    for (int j = 0; j < numbers.Length - 1; j++)
                    {
                        if (Convert.ToInt32(numbers[i]) > Convert.ToInt32(numbers[j]))
                        {
                            var temp = Convert.ToInt32(numbers[i]);
                            numbers[i] = numbers[j];
                            numbers[j] = temp.ToString();
                        }
                    }
                }
                Console.WriteLine("Greater Number is {0}", numbers[0]);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
