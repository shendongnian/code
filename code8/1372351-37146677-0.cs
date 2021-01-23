      public class NativeMethods
      {
        private const int LVM_FIRST = 0x1000;
        private const int LVM_SETITEMSTATE = LVM_FIRST + 43;
    
        private const int LVIF_STATE = 0x8;
    
        private const int LVIS_UNCHECKED = 0x1000;
        private const int LVIS_CHECKED = 0x2000;
        private const int LVIS_CHECKEDMASK = 0x3000;
    
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct LVITEM
        {
          public int mask;
          public int iItem;
          public int iSubItem;
          public int state;
          public int stateMask;
          [MarshalAs(UnmanagedType.LPTStr)]
          public string pszText;
          public int cchTextMax;
          public int iImage;
          public IntPtr lParam;
          public int iIndent;
          public int iGroupId;
          public int cColumns;
          public IntPtr puColumns;
        };
    
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageLVItem(IntPtr hWnd, int msg, int wParam, ref LVITEM lvi);
    
        /// <summary>
        /// Check all rows on the given listview
        /// </summary>
        /// <param name="list">The listview whose items are to be checked</param>
        public static void CheckAllItems(ListView list)
        { // -1 index means all items in the list
          SetItemState(list, -1, LVIS_CHECKEDMASK, LVIS_CHECKED);
        }
    
        /// <summary>
        /// Uncheck all rows on the given listview
        /// </summary>
        /// <param name="list">The listview whose items are to be unchecked</param>
        public static void UncheckAllItems(ListView list)
        { // -1 index means all items in the list
          SetItemState(list, -1, LVIS_CHECKEDMASK, LVIS_UNCHECKED);
        }
    
        /// <summary>
        /// Set the item state on the given item
        /// </summary>
        /// <param name="list">The listview whose item's state is to be changed</param>
        /// <param name="itemIndex">The index of the item to be changed</param>
        /// <param name="mask">Which bits of the value are to be set?</param>
        /// <param name="value">The value to be set</param>
        public static void SetItemState(ListView list, int itemIndex, int mask, int value)
        {
          LVITEM lvItem = new LVITEM();
          lvItem.mask = LVIF_STATE;
          lvItem.stateMask = mask;
          lvItem.state = value;
          SendMessageLVItem(list.Handle, LVM_SETITEMSTATE, itemIndex, ref lvItem);
        }
      }
