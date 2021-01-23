    for (int i = 0; i < progressBar1.Maximum+1; i++)
    {                    
        MessageBox.Show(listeksnya.ElementAt(i));
        double val = (i + 1) * 100d / listeksnya.Count; //note the d to avoid 
        progressBar1.Value = (int)val; //this is correct now, cast to int if necessary
    }                
