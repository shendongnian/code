    private void btnDisplay_Click(object sender, EventArgs e)
    {
        double number = 0.0;
        string sqrt = string.Empty;
        try
        {
            number = Convert.ToDouble(tbInput.Text);
            
            //Why cant i just have it as "number=COnvert.ToDouble(tbInput.Text)?//
            //Convert.ToDouble(number);
            
            if (number < 0)
            {
                throw new NegativeNumberException();
            }
            sqrt = Math.Sqrt(number).ToString();
        }
        catch (FormatException error)
        {
            lbOutput.Items.Add(error.Message);
            lbOutput.Items.Add("The input should be a number.");
            sqrt = "not able to be calculated";
        }
        catch (NegativeNumberException neg)
        {
            lbOutput.Items.Add(neg.Message);
            sqrt = "not able to be calculated";
        }
        finally
        {
            //Here is where i am having the issue "Unassigned local variable"//
            lbOutput.Items.Add("Square Root " + sqrt);
        }
    }
