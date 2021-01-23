    int MaxViewers = Convert.ToInt32(txtNoRecordsToAdd.Text);
    int minClosestTargetRequired = 0;
    int closestSum = int.maxValue;
    int closestSetIndex = -1;
    var subsets = MyExtensions.SubSetsOf(List1);
    for(var c = 0 ; c < subsets.Count() ; c++)
    {
      int currentSum = subsets[c].Sum(o=> o);
      if(currentSum < closestSum)
      {
        closestSum = currentSum;
        closestSetIndex = c;
      }
      if(closestSum <= minClosestTargetRequired)
        break;
    }
    Console.WriteLine("Closest Sum Is {0} In Set Index {1},closestSum,closestSetIndex);
