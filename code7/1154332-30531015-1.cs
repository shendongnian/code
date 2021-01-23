       using UnityEngine;
       using System;
       using System.IO;
       using System.Reflection;
       using System.Runtime.Serialization.Formatters.Binary;
       using System.Runtime.Serialization.Formatters.Soap;
       using System.Runtime.Serialization;
       PlayerProfile _playerProfile;
       public void SaveProfile()
       {
          //IFormatter formatter = new BinaryFormatter();
          IFormatter formatter = new SoapFormatter();
    
          string fileName = "my.profile";
    
          FileStream stream = new FileStream( fileName, FileMode.Create );
          formatter.Serialize( stream, _playerProfile );
          stream.Close();
       }
    
       public bool LoadProfile()
       {
          //IFormatter formatter = new BinaryFormatter();
          IFormatter formatter = new SoapFormatter();
    
          string fileName = "my.profile";
    
          if( !File.Exists( fileName ) )
             return false;
    
          FileStream stream = new FileStream( fileName, FileMode.Open );
          _playerProfile = formatter.Deserialize( stream ) as PlayerProfile;
          stream.Close();
    
          return true;
       }
