     int ChildNumber = VisualTreeHelper.GetChildrenCount(grid2);
                for (int i = 0; i < ChildNumber; i++)
                {
                    Control v = (Control)VisualTreeHelper.GetChild(grid2, i);
    
                    if (v.GetType().ToString() == "Project_wpf.UserControlRef")
                    {
                        UserControlRef CM = v as UserControlRef;
                        Console.WriteLine(CM.Name); //you can check his name here
                        CM.myReset();
                        
                    }
                }
