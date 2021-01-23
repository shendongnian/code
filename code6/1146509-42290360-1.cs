     public static void Replace(Microsoft.Office.Interop.Word.Range rng, string OldValue, object NewValue)
     {
            object missing = System.Reflection.Missing.Value;
            try
            {
                Find findObject = rng.Find;
                findObject.ClearFormatting();
                findObject.Text = OldValue;
                findObject.Replacement.ClearFormatting();
                findObject.Format = true;
                
                object replaceAll = WdReplace.wdReplaceAll;
                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, NewValue,
                   ref replaceAll, ref missing, ref missing, ref missing, ref missing);
            }
            catch (System.Exception e)
            {
                throw e;
            }
    }
