      public static bool WriteLog_Reflection(string fileName, long maxLogSizeMB, IEnumerable newObcObject, out string strError) {
          try {
            strError = string.Empty;
            string lines = string.Empty;
            foreach (var item in newObcObject) {
              foreach (var prop in item.GetType().GetProperties()) {
                //string str = prop.Name + " = " + prop.GetValue(item, null).ToString();
                lines += prop.GetValue(item, null).ToString() + "; ";
              }
            }
    
            return true;
          } catch (Exception exc) {
            strError = exc.ToString();
            return false;
          }
        }
      }
