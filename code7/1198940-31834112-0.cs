	using System;
	using System.Diagnostics;
	using System.Runtime.InteropServices;
	using System.Windows.Forms;
	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
		{
			private const uint WINEVENT_OUTOFCONTEXT = 0x0000;
			private const uint EVENT_OBJECT_LOCATIONCHANGE = 0x800B;
			private const uint EVENT_SYSTEM_MOVESIZESTART = 0x000A;
			private const uint EVENT_SYSTEM_MOVESIZEEND = 0x000B;
			public Form1()
			{
				InitializeComponent();
			}
			private void Form1_Load(object sender, EventArgs e)
			{
				this.Width = 100;
				this.Height = 100;
				this.TopMost = true;
				int processId = Process.GetProcessesByName("OUTLOOK")[0].Id;
				//this will also be triggered by mouse moving over the process windows
				//NativeMethods.SetWinEventHook(EVENT_OBJECT_LOCATIONCHANGE, EVENT_OBJECT_LOCATIONCHANGE, IntPtr.Zero, WinEventProc, (uint)processId, (uint)0, WINEVENT_OUTOFCONTEXT);
				NativeMethods.SetWinEventHook(EVENT_SYSTEM_MOVESIZESTART, EVENT_SYSTEM_MOVESIZEEND, IntPtr.Zero, WinEventProc, (uint)processId, (uint)0, WINEVENT_OUTOFCONTEXT);
			}
			private void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
			{
				Rect move = new Rect();
				if (eventType == EVENT_SYSTEM_MOVESIZESTART)
				{
					NativeMethods.GetWindowRect(hwnd, ref move);
					Debug.WriteLine("EVENT_SYSTEM_MOVESIZESTART");
				}
				else if (eventType == EVENT_SYSTEM_MOVESIZEEND)
				{
					NativeMethods.GetWindowRect(hwnd, ref move);
					Debug.WriteLine("EVENT_SYSTEM_MOVESIZEEND");
				}
				this.Left = move.Left;
				this.Top = move.Top;
			}
		}
		public struct Rect
		{
			public int Left { get; set; }
			public int Top { get; set; }
			public int Right { get; set; }
			public int Bottom { get; set; }
		}
		static class NativeMethods
		{
			[DllImport("user32.dll")]
			public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);
			public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
			[DllImport("user32.dll")]
			public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);
		}
	}
