    [Serializable()]    //Set this attribute to all the classes that want to serialize
    public class User : ISerializable //derive your class from ISerializable
    {
        public int userInt;
        public string userName;
        
        //Default constructor
        public User()
        {
            userInt = 0;
            userName = "";
        }
       //Deserialization constructor.
       public User(SerializationInfo info, StreamingContext ctxt)
       {
          //Get the values from info and assign them to the appropriate properties
          userInt = (int)info.GetValue("UserInt", typeof(int));
          userName = (String)info.GetValue("UserName", typeof(string));
       }
        
       //Serialization function.
       public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
       {
          //You can use any custom name for your name-value pair. But make sure you
          // read the values with the same name. For ex:- If you write userInt as "UserInt"
          // then you should read the same with "UserInt"
          info.AddValue("UserInt", userInt);
          info.AddValue("UserName", userName);
      }
    }
