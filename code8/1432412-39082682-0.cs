    public class UserData : DynamicObject
    {
     public UserData()
      {
        Id = 100;
        Name = "Superuser";
        Custom1 = new KeyValuePair<string, double>("HelloWorld1", 1);
        Custom2 = new KeyValuePair<string, double>("HelloWorld2", 2);
      }
     public id Id { get; set; }
     public string Name { get; set; }
     public KeyValuePair<string, double> Custom1 { get; set; }
     public KeyValuePair<string, double> Custom2 { get; set; }
     public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            string name = binder.Name;
            result = null;
            if(name.Equals(Custom1.Key)) 
                result = Custom1.Value;
            else if(name.Equals(Custom2.Key))
                result = Custom2.Value;
            return result != null;
        }
      public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {         
          string name = binder.Name;
          if(name.Equals(Custom1.Key)) 
            Custom1.Value = value;
          else if(name.Equals(Custom2.Key))
            Custom2.Value = value;
          return name.Equals(Custom1.Key) || 
                 name.Equals(Custom2.Key);
        }
      }
