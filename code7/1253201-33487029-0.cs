                double[] group1 = { 1, 2, 3, 4 };
                double[] group2 = { 5, 6, 7, 8 };
    
                double multipliedNumbers = 0;
    
                double totalCount = group1.Count() * group2.Count();
                double percentageDone = 0;
    
                double steps = 0;
    			
    			
    		 	var bworker = new BackgroundWorker();
                bworker.DoWork += (s, e) =>
                {
                	foreach (double x in group1)
              	    {
    
                    	foreach (double y in group2)
                   		{
                        	multipliedNumbers = x * y;
    						steps++;
    						
    						this.Invoke((MethodInvoker)delegate()
                    		{
                       	 		txtBlock.Text = multipliedNumbers.ToString();
                        		percentageDone = steps / totalCount * 100;
                        		progBar.Value = percentageDone;
    						});
                    	}
                	}
    			};
    			bworker.RunWorkerAsync();
