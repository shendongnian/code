    var type = this.GetType();
    for(int d=1;d<=365;d++) 
    {
      for(int h=1; h<=24; h++)
      {
          var name = string.Format("csv_{0:000}_{1:00}", d, h);
          sMntHour[d,h] = (int)type.GetField(name).GetValue(this);
      }
    }    
