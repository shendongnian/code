     public class MultiDimList: Dictionary<string, string>  { }
     MultiDimList myDicList = new MultiDimDictList ();
     for(int i; i<OldLinks.Count ; i++)
     {
       myDicList.Add(OldLinks[i].ToString(), NewLinks[i].ToString()); 
     }
