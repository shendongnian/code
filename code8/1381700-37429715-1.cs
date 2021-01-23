     public class MultiDimList: Dictionary<string, string>  { }
     MultiDimList NewList = new MultiDimList ();
     for(int i; i<OldLinks.Count ; i++)
     {
       NewList.Add(OldLinks[i].ToString(), NewLinks[i].ToString()); 
     }
