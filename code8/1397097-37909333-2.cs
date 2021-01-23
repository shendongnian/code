    var arrayMin = listOfInt;
    int currentNum = 0;
    int yourNum = int.MaxValue;
    bool isSuccess = true;
    foreach (var item in listOfInt)
    {
        if (int.TryParse(item.ToString(), out currentNum) && currentNum <= yourNum)
        {
            yourNum = currentNum;
        }
        else
        {
            isSuccess = false;
            break;
        }              
    }
    if(isSuccess)
        Console.WriteLine("Minimum Number in the array is {0}",yourNum);
    else
        Console.WriteLine("Invalid input element found");
