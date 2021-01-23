    public class Bicycle
    {
        public int BicycleID { get; set; }
        
        public int MemberID { get; set; }  // You can call this ownerId, but then you need to setup the relationship with annotation or fluent
        public virtual Member Owner { get; set; }
    }
    public void bicycle_set_FK(int IDbicycle, int IDmember)
    {
       var bicycleToFind = BicycleDB.Find(IDbicycle);
       // var memberToSetAsFK = MemberDB.Find(IDmember); ** Don't need to do this since you have FK **
       bicycleToFind.MemberId = IDmember;
       SaveChanges();
    }
