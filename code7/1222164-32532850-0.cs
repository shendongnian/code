    public static class RichTextBoxNativeMethods
    {
        private static CHARFORMAT2 GetCharFormat(this RichTextBox richTextBox, bool fSelection)
        {
            // Either CHARFORMAT or CHARFORMAT2 can be used as long as the cbSize is set correctly.
            // https://msdn.microsoft.com/en-us/library/windows/desktop/bb774230.aspx
            // Force handle creation
            if (!richTextBox.IsHandleCreated)
            {
                var handle = richTextBox.Handle;
            }
            var cf2 = new CHARFORMAT2();
            UnsafeNativeMethods.SendMessage(new HandleRef(richTextBox, richTextBox.Handle), RichTextBoxConstants.EM_GETCHARFORMAT, fSelection ? RichTextBoxConstants.SCF_SELECTION : RichTextBoxConstants.SCF_DEFAULT, cf2);
            return cf2;
        }
        public static void SetSelectionCharOffsetInTwips(this RichTextBox richTextBox, int offsetInTwips)
        {
            // Adapted from http://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/RichTextBox.cs,7765c7694b8e433f
            // Force handle creation
            if (!richTextBox.IsHandleCreated)
            {
                var handle = richTextBox.Handle;
            }
            var cf2 = new CHARFORMAT2();
            cf2.dwMask = RichTextBoxConstants.CFM_OFFSET;
            cf2.yOffset = offsetInTwips;
            UnsafeNativeMethods.SendMessage(new HandleRef(richTextBox, richTextBox.Handle), RichTextBoxConstants.EM_SETCHARFORMAT, RichTextBoxConstants.SCF_SELECTION, cf2);
        }
        public static int GetSelectionCharOffsetInTwips(this RichTextBox richTextBox)
        {
            // Adapted from http://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/RichTextBox.cs,7765c7694b8e433f
            int selCharOffset = 0;
            var cf2 = richTextBox.GetCharFormat(true);
            if ((cf2.dwMask & RichTextBoxConstants.CFM_OFFSET) != 0)
            {
                selCharOffset = cf2.yOffset;
            }
            else
            {
                // The selection contains characters of different offsets,
                // so we just return the offset of the first character.
                selCharOffset = cf2.yOffset;
            }
            return selCharOffset;
        }
    }
    public static class NativeMethods
    {
        public const int WM_USER = 0x0400;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CHARFORMAT2
    {
        // http://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/NativeMethods.cs,acde044a28b57a48
        // http://pinvoke.net/default.aspx/Structures/CHARFORMAT2.html
        public int cbSize = Marshal.SizeOf(typeof(CHARFORMAT2));
        public int dwMask;
        public int dwEffects;
        public int yHeight;
        public int yOffset;
        public int crTextColor;
        public byte bCharSet;
        public byte bPitchAndFamily;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szFaceName;
        public short wWeight;
        public short sSpacing;
        public int crBackColor;
        public int lcid;
        public int dwReserved;
        public short sStyle;
        public short wKerning;
        public byte bUnderlineType;
        public byte bAnimation;
        public byte bRevAuthor;
        public byte bReserved1;
    }
    public static class RichTextBoxConstants
    {
        // Trimmed down from
        // http://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/RichTextBoxConstants.cs,31b52ac41e96a888
        /* EM_SETCHARFORMAT wparam masks */
        /* EM_SETCHARFORMAT wparam masks */
        internal const int SCF_SELECTION = 0x0001;
        internal const int SCF_WORD = 0x0002;
        internal const int SCF_DEFAULT = 0x0000;   // set the default charformat or paraformat
        internal const int SCF_ALL = 0x0004;   // not valid with SCF_SELECTION or SCF_WORD
        internal const int SCF_USEUIRULES = 0x0008;   // modifier for SCF_SELECTION; says that
                                                    // the format came from a toolbar, etc. and
                                                    // therefore UI formatting rules should be
                                                    // used instead of strictly formatting the
                                                    // selection.
        internal const int EM_SETCHARFORMAT = (NativeMethods.WM_USER + 68);
        internal const int EM_GETCHARFORMAT = (NativeMethods.WM_USER + 58);
        internal const int CFM_BACKCOLOR = 0x04000000;
        internal const int CFM_OFFSET = 0x10000000;
        /* NOTE: CFE_AUTOCOLOR and CFE_AUTOBACKCOLOR correspond to CFM_COLOR and
           CFM_BACKCOLOR, respectively, which control them */
        internal const int CFE_AUTOBACKCOLOR = CFM_BACKCOLOR;
    }
