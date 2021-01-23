     public static int getSum(string input)
        {
            try
            {
                int num1, num2;
                string[] param = input.Split(' ');
                if (!int.TryParse(param[0], out num1)) { return 0; }
                if (!int.TryParse(param[2], out num2)) { return 0; }
                switch (param[1])
                {
                    case "+":
                        return num1 + num2;
                    case "-":
                        return num1 - num2;
                    case "/":
                        return num1 / num2;
                    case "*":
                        return num1 * num2;
                    default:
                        return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
