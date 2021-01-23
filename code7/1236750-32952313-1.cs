     public static async Task<List<Response>> Execute(Request objInput)
     {
           List<Response> objList = new List<Response>();
           foreach (object obj in objInput.objs)
            {
                objList.Add(await Task.Run(() =>GetDataFromDB(obj)));
            }
      return objList;
     }
      private static object GetDataFromDB(object obj)
      {
           //Call DB and build the object
      }
