     private List<string[]> FilterData(List<string[]> datatable)
        {
            // List is made of String Array, so need string[] variable not list
            string[] previousRow = null ;
            string[] currentRow;
            string[] rowDifferences ;
            // to store the result
            List<string[]> resultingDataset = new List<string[]>();
            foreach (var item in datatable)
            {
                if (previousRow == null)
                {
                    previousRow = item;
                    resultingDataset.Add(previousRow); // add first item to list
                    continue;
                }
                currentRow = item; 
                
                // check and replace with "-" if elment exist in previous 
                rowDifferences = currentRow.Select((x, i) => currentRow[i] == previousRow[i] ? "-" : currentRow[i]).ToArray();  
                resultingDataset.Add(rowDifferences);
                // make current as previos
                previousRow = item;
            }
            return resultingDataset;
        }
