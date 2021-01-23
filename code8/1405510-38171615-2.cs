    bool finalCondition = false;
    bool a = !GetFrameToDeviceTransformation(...);
    if (a == true)
     {
     finalCondition = true;
     }
    else
     {
     bool b = !GetFrameToDeviceTransformation(...);
     if (b == true)
      {
      finalCondition = true;
      }
     }
    if (finalCondition)
     {
     pair whatever...
     }
