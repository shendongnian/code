     ArrayList aryTest = new ArrayList();
                aryTest.Add("1");
                aryTest.Add("2");
                aryTest.Add("3");
                string strTest = "";            
     strTest = aryTest.ToArray().Aggregate((current, next) => current + "#" + next).ToString();
