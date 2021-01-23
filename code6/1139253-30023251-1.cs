         ...
         Microsoft.Office.Interop.Excel comObject = null;
         try{
            //Open comObject
            //Here I would call some functions, and have nested exceptions
         }
         catch(nestedException err)
         {
              //Handle at your discretion
         }
         finally{
              Utility.disposeComObject(ref comObject);
         }
