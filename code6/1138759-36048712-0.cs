        private MENUITEMINFO CreateSubMenu(string menuText, IntPtr menuIcon, IntPtr hSubMenu, bool isEnabled = true)
        {
            MENUITEMINFO subMenu = new MENUITEMINFO();
            subMenu.cbSize = (uint)Marshal.SizeOf(subMenu);
            subMenu.fMask = MIIM.MIIM_BITMAP | MIIM.MIIM_SUBMENU | MIIM.MIIM_STRING | MIIM.MIIM_FTYPE | MIIM.MIIM_STATE;
            subMenu.hSubMenu = hSubMenu;
            //subMenu.wID = itemID;
            subMenu.fType = MFT.MFT_STRING;
            subMenu.dwTypeData = menuText;
            subMenu.fState = isEnabled ? MFS.MFS_ENABLED : MFS.MFS_DISABLED;
            subMenu.hbmpItem = menuIcon;
            //itemID++;
            return subMenu;
        }
