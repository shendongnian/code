        private void btCalculate_Click(object sender, RoutedEventArgs e)
        {
            string expression = tboxExpression.Text;    //"cost * item / 100" (IT MUST BE SEPARATED WITH SPACES!)
            string variable1 = tboxVariable1.Text;      //"item=10"
            string variable2 = tboxVariable2.Text;      //"cost=2.5"
            DynamicFormula math = new DynamicFormula();
            math.Expression = expression;   //Let's define the expression
            math.AddVariable(variable1);    //Let's add the first variable
            math.AddVariable(variable2);    //Let's add the second variable
            try
            {
                double result = math.CalculateResult(); //In this scenario the result is 0,25... cost * item / 100 = (2.5 * 10 / 100) = 0,25
                //Console.WriteLine("Success: " + result);
                tboxResult.Text = result.ToString();
            }
            catch(Exception ex)
            {
                //Console.WriteLine(ex.Message);
                tboxResult.Text = ex.Message;
            }
        }
