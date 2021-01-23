          public string getString()
            {
                if (employeename.Length > 19)
                {
                     return employeename.Substring(0, 19).Trim();
                }
                else
                {
                      //return error OR
                      return employeename;
                }
            }
