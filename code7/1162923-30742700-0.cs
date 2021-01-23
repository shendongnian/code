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
		static MyStruct ReadStruct(string path)
		{
			byte[] bytes = File.ReadAllBytes(path);
			var utf8 = new UTF8Encoding();
			var retval = new MyStruct();
			int index = 0;
			retval.Name = utf8.GetString(bytes, index, 127);
			index += 127;
			index += 2;
			retval.MailBox = utf8.GetString(bytes, index, 149);
			index += 149;
			index += 2;
			retval.RouteID = utf8.GetString(bytes, index, 10);
			return retval;
		}
		// http://stackoverflow.com/questions/30742019/reading-binary-file-into-struct
		static void Main(string[] args)
		{
			MyStruct ms = ReadStruct("MY_STRUCT.data");
		}
	}
    }
