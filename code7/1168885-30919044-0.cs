    using UnityEngine;
    using System;
    using System.Runtime.Serialization;
    
    [Serializable]
    public class BasePrefabSaveData : ISerializable
    {
       public Vector3 _Position;
    
       public BasePrefabSaveData()
       {
       }
    
       public BasePrefabSaveData(SerializationInfo info, StreamingContext context)
       {
          _Position.x = (float)info.GetValue( "Position.x", typeof( float ) );
          _Position.y = (float)info.GetValue( "Position.y", typeof( float ) );
          _Position.z = (float)info.GetValue( "Position.z", typeof( float ) );
       }
    
       public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
       {
          info.AddValue( "Position.x", _Position.x, typeof( float ) );
          info.AddValue( "Position.y", _Position.y, typeof( float ) );
          info.AddValue( "Position.z", _Position.z, typeof( float ) );
       }
    }
