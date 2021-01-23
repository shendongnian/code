    for (int i = 1; i <= totalRows; i++)
    {
        if (testScenarioId.Equals(workSheet.Cells[i, 1].Value) && 
            testCaseId.Equals(workSheet.Cells[i, 2].Value) )
        {
            //Console.Write("Desired Row is: " + i);
            myArray = new string[totalColums];
            for (int j = 1; j < totalColums; j++)
            {
                myArray.SetValue(workSheet.Cells[i, j].Value.ToString(), (j - 1));
            }
            // stop iterating the for loop
            break;
        }
    }
