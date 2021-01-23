            dContainer.Add(_dCharStats, dCharStats);
            dContainer.Add("_dMapStats", dMapStats);
            object secondObj = (object)dCharStats;
             
            dynamic someObj = dContainer[_dCharStats];
           
            foreach (dynamic blah in someObj)
            {
                dynamic internalObj = blah.Value;
                int somevalue = internalObj.GetType().GetProperty("Stamina").GetValue(internalObj, null);
                internalObj.GetType().GetProperty("Stamina").SetValue(internalObj, 8080, null);
            }
            Console.WriteLine("After:"+dCharStats["MC"].Stamina);
            Console.WriteLine("After:" + dCharStats["MC"].maxStamina);
