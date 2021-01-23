    var demo = demoTest.Select(s =>
               {
                s.Fourthth_member = dic.GetValueFromDictonary(s.Fourthth_member);
                s.Fifthth_member = dic1.GetValueFromDictonary(s.Fifthth_member);
                return s;
              }).ToList();
    //Extension method
    public static class extMethod
    {
      public static int GetValueFromDictonary(this Dictionary<int, int> dic, int key)
        {
            int value = 0;
            dic.TryGetValue(key, out value);
            return value;
        }
    }
