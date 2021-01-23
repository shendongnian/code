    public ActionResult Index()
    {
        var numberList = new List<int>();
        numberList.AddRange(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        var totalNumber = 0;
        var numberListTemp = numberList;
        foreach (var item in umberListTemp)
        {
            totalNumber += item;
            if (item == 5)
            {
                numberList.Remove(item);
            }
        }
        return View(totalNumber);
    }
