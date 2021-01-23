    using System;
    using System.IO;
    using System.Runtime.Serialization;
    
    [Serializable]
    public class PlayerProfile : ISerializable
    {
       private string _profileName;
       private string _saveGameFolder;
    
       public PlayerProfile()
       {
       }
    
       public PlayerProfile(SerializationInfo info, StreamingContext context)
       {
          _profileName = (string)info.GetValue( "ProfileName", typeof( string ) );
          _saveGameFolder = (string)info.GetValue( "SaveGameFolder", typeof( string ) );
       }
    
       public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
       {
          info.AddValue( "ProfileName", _profileName, typeof( string ) );
          info.AddValue( "SaveGameFolder", _saveGameFolder, typeof( string ) );
       }
    }
