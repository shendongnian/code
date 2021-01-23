     [ProtoContract]
     public class AnotherObject : SomeObject{
         [ProtoMember(1, DynamicType = true)]
         public object[] someList{ get; set: }
     } 
