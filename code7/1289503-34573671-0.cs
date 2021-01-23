      string Output = "";
         while (Counter < 24.0f)
            {
              
                Output += Counter;
                txtAvgTemp.Text = Output.ToString();
                Counter += 1.5f;
                txtAvgTemp.Text.Split('\n');
            }
