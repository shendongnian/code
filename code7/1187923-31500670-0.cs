    public class User
    {
      public int Id { get; set; }
      public ICollection<Follower> Followers { get; set; }
    }
    
    public enum EFollowerType
    {
        Follower=1,
        Following
    }
    
    public class Follower
    {
      public int Id { get;  set; }
      public int UserId { get; set; }
      public EFollowerType FollowerType { get; set; }
      
      public User User { get; set; }
    }
    
    
    //to add a follower 
    var user = ... user details goes here ... 
    var follower = new Follower(){
       FollowerType = FollowerType.Follower, // if you want it as Follower
       User = user,
    };
    db.Followers.Add(follower);
    db.SaveChanges();
    // to know how many followers the user has
    
    var followers = user.Followers.Count(t=>t.FollowerType ==EFollowerType.Follower);
    
    // to know how many the user is following 
    var followers = user.Followers.Count(t=>t.FollowerType ==EFollowerType.Following);
