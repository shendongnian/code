    public class Member 
    { 
      internal string Key ; 
      internal int    Source ; 
      internal object DataObject ;
      internal Member(string key,string source,object dataobject)
      { // source identifies the source, e.g "P" for Prod and "I" for Inventory
        Key = key ;
        Source = Source ; 
        DataObject = dataobject 
      }
    }
    
    // create and fill the merged list  
    List<Member> list = new List<member>();
    for (int i=0;i<db.tbl_ProdCodeValues.Count;i++) 
    {
      string prodcodevalue = ... ; // set the value here
      object prodcodeobject= ... ; // set the record object here
      list.Add(new Member(prodcodevalue,1,prodcodeobject) ;
    }
    for (int i=0;i<db.tbl_InventoryCodeValues.Count;i++) 
    {
      string inventorycodevalue= ... ; // set the value here
      object inventorycodeobject= ... ; // set the record object here
      list.Add(new Member(inventorycodevalue,2,inventorycodeobject) ;
    }
    // sort the merged list 
    list.Sort(delegate(Member x, Member y) { return (x.Key+" "+x.Source).CompareTo(y.Key+" "+y.Source); });
    // Process the merged list
    // we assume that a key cannot be empty
    list.Add(new Member("",0,null) ; // just for proper termination of next loop
    string CurKey="" ;
    int starti=-1 ; int endi=-1 ; 
    int startp=-1 ; int endp=-1 ;  
    for (int n=0;n<list.Count;n++)
    {
      if (list[n].Key==CurKey) { if (list[n].Source="I") endi=n ; if (list[n].Source="P") endp=n ;
      else 
      {
        if (CurKey!="" ) 
        { // -------- Process the CurKey for matches ---------
          // The Prod      records corresponding to CurKey are given by list[p].dataobject whith p from startp to endp  
          // The Inventory records corresponding to CurKey are given by list[i].dataobject whith i from starti to endi 
          // if either starti or startp is negative, there is no match
          ... // insert your business code there
        }
        if (list[n].Source="I") { starti=endi=n  ; startp=endp=-1 ; }
        if (list[n].Source="P") { starti=endi=-1 ; startp=endp=n  ; }
    }
