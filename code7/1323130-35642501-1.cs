            try
            {
                List<int> myIntegers = txtInputNumber.Text.Split(',').Select(x => Convert.ToInt32(x)).ToList();
            }
            catch
            {
              // Display error here
              // Input is not valid; 
            }
