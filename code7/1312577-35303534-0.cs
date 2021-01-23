        for (int i = 0; i <= 12; i++) //Perform the iterative loop
        {
            double val;
            if (G481Inputs[i].Value != "")
            {
                double.TryParse(G481Inputs[i].Value, out val);
                G481List[i] = val;
            }
        }
    
