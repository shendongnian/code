            string aheading = "Defects:";
            string bheading = "Comments:";
            string result = aheading.PadRight(20, ' ') + bheading.PadRight(20, ' ') + Environment.NewLine ;
            foreach (var item in chkList.CheckItems)
            {
                if (item.Defect == true)
                {
                    string result += item.ItemTitle.Trim().PadRight(20,' ') +  item.ItemTitle.Trim().PadRight(20,' ') + Environment.NewLine ; 
                    
                }
            }
            Console.WriteLine(result);
