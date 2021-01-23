    using System.Text;
    using System.IO;
    namespace ReadCppStruct
    {
	/*
	 typedef struct myStruct{
		char Name[127];
		char s1[2];
		char MailBox[149];
		char s2[2];
		char RouteID[10];
		} MY_STRUCT;
	 */
	class MyStruct
	{
		public string Name { get; set; }
		public string MailBox { get; set; }
		public string RouteID { get; set; }
	}
	class Program
	{
		static string GetString(Encoding encoding, byte[] bytes, int index, int count)
		{
			string retval = encoding.GetString(bytes, index, count);
			int nullIndex = retval.IndexOf('\0');
			if (nullIndex != -1)
				retval = retval.Substring(0, nullIndex);
			return retval;
		}
		static MyStruct ReadStruct(string path)
		{
			byte[] bytes = File.ReadAllBytes(path);
			var utf8 = new UTF8Encoding();
			var retval = new MyStruct();
			int index = 0; int cb = 127;
			retval.Name = GetString(utf8, bytes, index, cb);
			index += cb + 2;
			cb = 149;
			retval.MailBox = GetString(utf8, bytes, index, cb);
			index += cb + 2;
			cb = 10;
			retval.RouteID = GetString(utf8, bytes, index, cb);
			return retval;
		}		// http://stackoverflow.com/questions/30742019/reading-binary-file-into-struct
		static void Main(string[] args)
		{
			MyStruct ms = ReadStruct("MY_STRUCT.data");
		}
	}
    }
