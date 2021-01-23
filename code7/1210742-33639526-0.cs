    #The following is an attempt to prevent the SceenSaver from kicking-in during installation
	#We call it using this
	#[ScreenSpender.PressKeyForMe]::Main()
	Add-Type @"
	using System;
	using System.Threading;
	using System.Runtime.InteropServices;
	namespace ScreenSpender 
	{
		public static class PressKeyForMe 
		{ 
			[DllImport("user32.dll")] 
			static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
			//public static void Main(string[] args)
			public static void Main()
			{
				//bScan = PS/2 scan code. (We happen to be using Set 1)
				// Make  = when you press the key
				// Break = when you release the key
				//VK_F15 0x7E
				//SC_F15 0x5D 	(Scan code set 1) (or 0x64) (http://www.quadibloc.com/comp/scan.htm  - by John Savard)
				//private const int KEYEVENTF_KEYUP = 0x02;
				//This code will press and hold the 'F15' key for 250 Milliseconds, and then will release for 200 Milliseconds
				keybd_event((byte)0x7E, (byte)0x5D, 0, UIntPtr.Zero);
				Thread.Sleep(250);
				
				// Release for 200 Milliseconds
				keybd_event((byte)0x7E, (byte)0x5D, (uint)0x2, UIntPtr.Zero);
				Thread.Sleep(200);
			}
		}
	}
	"@
