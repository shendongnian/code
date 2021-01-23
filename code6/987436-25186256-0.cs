    public static void MakeNewDesktopArea()
		{
			// Save current Working Area size
			m_rcOldDesktopRect.left = SystemInformation.WorkingArea.Left;
			m_rcOldDesktopRect.top = SystemInformation.WorkingArea.Top;
			m_rcOldDesktopRect.right = SystemInformation.WorkingArea.Right;
			m_rcOldDesktopRect.bottom = SystemInformation.WorkingArea.Bottom;
			// Make a new Workspace
			WinAPI.RECT rc;
			rc.left = SystemInformation.VirtualScreen.Left + 150;
			rc.top = SystemInformation.VirtualScreen.Top; // We reserve the 24 pixels on top for our taskbar
			rc.right = SystemInformation.VirtualScreen.Right;
			rc.bottom = SystemInformation.VirtualScreen.Bottom - 101;
			WinAPI.SystemParametersInfo((int)WinAPI.SPI.SPI_SETWORKAREA, 0, ref rc, 0);
		}
