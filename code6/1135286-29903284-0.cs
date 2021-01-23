	using UnityEngine;
	using System.Collections;
	using System;
	using System.Runtime.Serialization.Formatters.Binary;
	using System.IO;
	[Serializable]
	public class MyClass {
		public int myInt;
		
		public void Save(){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create (FilePath());
			bf.Serialize(file, this);
			file.Close();
		}
		
		public void Load(){
			if(File.Exists(FilePath())){
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(FilePath(), FileMode.Open);
				MyClass loaded = bf.Deserialize(file) as Brochure;
                myInt = loaded.myInt;
			}
		}
		static string FilePath()
		{
			return Application.persistentDataPath + "/myClass.dat";
		}
	}
