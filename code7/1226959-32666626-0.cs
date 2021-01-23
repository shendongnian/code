    public void bw_DoWork(object sender, DoWorkEventArgs e)
    {
       if (!Overall.stopStatus)
       {
           var viewModel = e.Argument as TestViewModel;
           for (int i=0; i < 10000; i++)
           {
               Overall.PercentageDwnd = i;
               viewModel.UpdatePercentage = i;
               Overall.caseRefId = "999999";
               if (i == 9998)
               {
                   i = 1;
               }
            }
        }
    }
