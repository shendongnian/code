	[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
	static extern short VkKeyScan(char ch);
	static void Main(string[] args)
	{
		char[] chars = "²³{[]}\\@€~|µ   °!`\"§$%&/()=?*'>;:_".ToCharArray();
		Console.WriteLine("char\talt\tcontrol\tshift" + Environment.NewLine + "-----------------------------");
		for (int i = 0; i < chars.Length; i++)
		{
			char ch = chars[i];
			short vksc = VkKeyScan(ch);
			bool alt = (vksc & 1024) == 1024;
			bool control = (vksc & 512) == 512;
			bool shift = (vksc & 256) == 256;
			Console.WriteLine(ch + "\t" + alt + "\t" + control + "\t" + shift);
		}
		Console.ReadKey();
	}
