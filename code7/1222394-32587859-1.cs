    /// <summary>
    ///     Method is used to INSERT data within JsonData table Recursively
    /// </summary>
    /// <author>
    ///  	Added 		:: Author : Irfan Ahmad
    /// </author> 
    /// <param name="message">JSonData Deserialized data as ExpandoObject</param>
    /// <param name="parentPath">Parent Path with "\" (Slash) seperated</param>
    /// <param name="ParentId">Parent ID</param>
    /// <param name="aFieldIndex">Field Index is used if Object is an Array</param>
    public void RecursiveMethod(ExpandoObject message, string parentPath, int ParentId, int aFieldIndex)
    {
        foreach (var item in message)
        {
            //System.Collections.Generic.Dictionary<string, string> keyValue = new System.Collections.Generic.Dictionary<string, string>();
            string K = string.Empty;
            string V = string.Empty;
            string Path = "";
            if (item.Value.GetType() == typeof(System.Dynamic.ExpandoObject) || item.ToString().Contains("System.Collections.Generic.List"))
            {
                int pID = 0;
                K = item.Key;
                pID = jData.Insert(MsgID, ParentId, parentPath, K, string.Empty, aFieldIndex);
                if (!string.IsNullOrEmpty(parentPath))
                {
                    Path = parentPath + "\\" + item.Key;
                }
                else
                {
                    Path = item.Key;
                }
                if (item.ToString().Contains("System.Collections.Generic.List"))
                {
                    IEnumerable temp = (IEnumerable)item.Value;
                    int fieldIndex = 0;
                    foreach (var innerItem in temp)
                    {
                        if (!string.IsNullOrEmpty(innerItem.ToString()))
                        {
                            InsertJsonDataRecursiveMethod((ExpandoObject)innerItem, Path, pID, fieldIndex);
                            fieldIndex += 1;
                        }
                        
                    }
                }
                else
                {
                    InsertJsonDataRecursiveMethod((ExpandoObject)item.Value, Path, pID, aFieldIndex);
                }
            }
            else
            {
                K = item.Key;
                V = item.Value.ToString();
                jData.Insert(MsgID, ParentId, parentPath, K, V, aFieldIndex);
            }
        }
    }
