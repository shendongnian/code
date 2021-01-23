	using System;
	using System.Threading;
	using System.Runtime.InteropServices;
	namespace kbd_events_example
	{
		static class Program
		{
			#pragma warning disable 649
			internal struct INPUT
			{
				public UInt32 Type;
				public KEYBOARDMOUSEHARDWARE Data;
			}
			[StructLayout(LayoutKind.Explicit)]
			//This is KEYBOARD-MOUSE-HARDWARE union INPUT won't work if you remove MOUSE or HARDWARE
			internal struct KEYBOARDMOUSEHARDWARE
			{
				[FieldOffset(0)]
				public KEYBDINPUT Keyboard;
				[FieldOffset(0)]
				public HARDWAREINPUT Hardware;
				[FieldOffset(0)]
				public MOUSEINPUT Mouse;
			}
			internal struct KEYBDINPUT
			{
				public UInt16 Vk;
				public UInt16 Scan;
				public UInt32 Flags;
				public UInt32 Time;
				public IntPtr ExtraInfo;
			}
			internal struct MOUSEINPUT
			{
				public Int32 X;
				public Int32 Y;
				public UInt32 MouseData;
				public UInt32 Flags;
				public UInt32 Time;
				public IntPtr ExtraInfo;
			}
			internal struct HARDWAREINPUT
			{
				public UInt32 Msg;
				public UInt16 ParamL;
				public UInt16 ParamH;
			}
			#pragma warning restore 649
			[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
			static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint extraInfo);
			[DllImport("user32.dll", SetLastError = true)]
			static extern int MapVirtualKey(uint uCode, uint uMapType);
			[DllImport("user32.dll", SetLastError = true)]
			static extern UInt32 SendInput(UInt32 numberOfInputs, INPUT[] inputs, Int32 sizeOfInputStructure);
			enum VK
			{
				MENU = 0x12,
				NUMPAD0 = 0x60,
				NUMPAD1 = 0x61,
				NUMPAD2 = 0x62,
				NUMPAD3 = 0x63,
				NUMPAD4 = 0x64,
				NUMPAD5 = 0x65,
				NUMPAD6 = 0x66,
				NUMPAD7 = 0x67,
				NUMPAD8 = 0x68,
				NUMPAD9 = 0x69
			}
			const uint KEYEVENTF_KEYUP = 0x0002;
			public const int INPUT_KEYBOARD = 1;
			[STAThread]
			static void Main()
			{
				Thread.Sleep(5000); //wait 5 seconds, so you can focus the Notepad
				keybd_event((int)VK.MENU, (byte)MapVirtualKey((uint)VK.MENU, 0), 0, 0); //Alt Press  
				keybd_event((int)VK.NUMPAD1, (byte)MapVirtualKey((uint)VK.NUMPAD1, 0), 0, 0); // N1 Press  
				keybd_event((int)VK.NUMPAD1, (byte)MapVirtualKey((uint)VK.NUMPAD1, 0), KEYEVENTF_KEYUP, 0); // N1 Release  
				keybd_event((int)VK.MENU, (byte)MapVirtualKey((uint)VK.MENU, 0), KEYEVENTF_KEYUP, 0); // Alt Release  	
				Thread.Sleep(2000); //wait 2 seconds
				INPUT[] inputs = new INPUT[] {
					new INPUT {Type = INPUT_KEYBOARD, Data = new KEYBOARDMOUSEHARDWARE { Keyboard = new KEYBDINPUT { Vk = (ushort)VK.MENU, Flags = 0, Scan = (ushort)MapVirtualKey((uint)VK.MENU, 0), ExtraInfo = IntPtr.Zero, Time = 0}}},
					new INPUT {Type = INPUT_KEYBOARD, Data = new KEYBOARDMOUSEHARDWARE { Keyboard = new KEYBDINPUT { Vk = (ushort)VK.NUMPAD2, Flags = 0, Scan = (ushort)MapVirtualKey((uint)VK.NUMPAD2, 0), ExtraInfo = IntPtr.Zero, Time = 0}}},
					new INPUT {Type = INPUT_KEYBOARD, Data = new KEYBOARDMOUSEHARDWARE { Keyboard = new KEYBDINPUT { Vk = (ushort)VK.NUMPAD2, Flags = 2, Scan = (ushort)MapVirtualKey((uint)VK.NUMPAD2, 0), ExtraInfo = IntPtr.Zero, Time = 0}}},
					new INPUT {Type = INPUT_KEYBOARD, Data = new KEYBOARDMOUSEHARDWARE { Keyboard = new KEYBDINPUT { Vk = (ushort)VK.MENU, Flags = 2, Scan = (ushort)MapVirtualKey((uint)VK.MENU, 0), ExtraInfo = IntPtr.Zero, Time = 0}}}
				};
				SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
			}
		}
	}
