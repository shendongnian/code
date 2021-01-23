    Cursor m_HandCursor = null;
    Cursor HandCursor
    {
        get
        {
            if (m_HandCursor == null)
            {
                m_HandCursor = CursorFromString(
                    "AAACAAEAICAAABAAFACoEAAAFgAAACgAAAAgAAAAQ{A5}EAI{A62}aBgM3GgYD/xoGA/8a" +
                    "BgP/GgYD/xoGA/8aBgP/GgYD/xoGA/8aBgO6{A70}GgYDNxoGA73Ny8r/39/f/93d3f/a2" +
                    "tr/2NjY/9bW1v/V1dX/09PT/xoGA94{A6a}BoGAzcaBgO909HR/+Xl5f/j4+P/4eHh/97e" +
                    "3v/c3Nz/2tra/9jY2P/W1tb/GgYD3hoGAz{A61}aBgM3GgYDvdnX1//s7Oz/6urq/+fn5/" +
                    "/l5eX/4+Pj/+Dg4P/e3t7/3Nzc/9ra2v8aBgOHGgYDhw{A5f}BoGA73f3dz/8/Pz//Hx8f" +
                    "/u7u7/7Ozs/+np6f/n5+f/5OTk/+Li4v/g4OD/3d3d/7Kurf8aBgPV{A5b}aBgNjGgYDtP" +
                    "n5+f/IxMP/9fX1//Ly8v/w8PD/7u7u/+vr6//p6en/5ubm/+Tk5P/i4uL/39/f/xoGA94a" +
                    "BgMw{A50}GgYDNhoGA7rm5OT//Pz8/4N5d//4+Pj/9vb2//T09P/y8vL/8PDw/+3t7f/r6" +
                    "+v/6Ojo/+bm5v/j4+P/GgYDhxoGA4c{A50}aBgO66Obl{/7}+/v7/GgYD//v7+//6+vr/+" +
                    "Pj4//b29v/09PT/8vLy/+/v7//t7e3/6urq/+jo6P+6trX/GgYD1Q{A4f}BoGA//o5uX/6" +
                    "Obl/xoGA7oaBgP//v7+//39/f/7+/v/+fn5//j4+P/19fX/8/Pz//Hx8f/v7+//7Ozs/+r" +
                    "q6v8aBgP/{A50}GgYDuhoGA/8aBgO6GgYDNhoGA{/d}7+/v/8/Pz/+/v7//n5+f/39/f/9" +
                    "fX1//Pz8//x8fH/7u7u/xoGA/8{A65}GgYD{/17}9/f3//Pz8//r6+v/5+fn/GgYD//X19" +
                    "f/y8vL/GgYD/w{A65}aBgP{/c}Pysr{/b}8aBgP//f39//z8/P8aBgP/+Pj4//b29v8aBg" +
                    "P/{A60}GgYDMDgmJP{/b}4Z7ev{/b}xoGA{/8}v7+/xoGA//7+/v/+vr6/xoGA/8{A60}a" +
                    "BgOHhnt6{/c}QC8t{/c}GgYD{/c}GgYD//7+/v/9/f3/GgYD/w{A5f}BoGA9XPysr{/6}8" +
                    "/Kyv8aBgP{/b}8aBgP{/b}8aBgP{/6}8/Kyv8aBgO6{A60}GgYD{/c}GgYDhxoGA{/c}xo" +
                    "GA{/c}xoGA//Pysr/GgYDuhoGAxo{A60}aBgP{/b}8aBgOHGgYD{/c}GgYD{/7}Pysr/Gg" +
                    "YD/xoGA7oaBgMa{A65}BoGA7r{/a}xoGA4caBgP{/b}8aBgP/GgYD/xoGA7oaBgM2{A70}" +
                    "GgYDNhoGA7oaBgO6GgYDNhoGA7r{/a}xoGA7o{A95}GgYDNhoGA7oaBgO6GgYDNg{A84a}" +
                    "//AD///gA///wAH//4AB//+AAf//AAD//gAA//4AAP/+AAD//gAA///gAP//4AD//8AA//" +
                    "/AAP//wAD//8AA///AAf//wAf//8A////8P{/41}8=");
            }
            return m_HandCursor;
        }
    }
    Cursor m_HandGrabCursor = null;
    Cursor HandGrabCursor
    {
        get
        {
            if (m_HandGrabCursor == null)
            {
                m_HandGrabCursor = CursorFromString(
                    "AAACAAEAICAAABAAFACoEAAAFgAAACgAAAAgAAAAQ{A5}EAI{A62}aBgM3GgYD/xoGA/8a" +
                    "BgP/GgYD/xoGA/8aBgP/GgYD/xoGA/8aBgO6{A70}GgYDNxoGA73Pzc3/4eHh/97e3v/b2" +
                    "9v/2dnZ/9bW1v/U1NT/0tLS/xoGA94{A6a}BoGAzcaBgO919XV/+rq6v/n5+f/4+Pj/+Dg" +
                    "4P/d3d3/29vb/9jY2P/W1tb/GgYD3hoGAz{A61}aBgM3GgYDvd/d3P/y8vL/7+/v/+zs7P" +
                    "/p6en/5ubm/+Pj4//g4OD/3d3d/9ra2v8aBgOHGgYDhw{A5f}BoGA73l4+P/+vr6//f39/" +
                    "/19fX/8vLy/+/v7//r6+v/6Ojo/+Xl5f/i4uL/39/f/7Ovrv8aBgPV{A5b}aBgNjGgYDtP" +
                    "{/5}Nycj/+/v7//n5+f/39/f/9PT0//Hx8f/u7u7/6+vr/+fn5//k5OT/4eHh/xoGA94aB" +
                    "gMw{A50}GgYDNhoGA7ro5uX{/6}4Z7ev/+/v7//f39//v7+//5+fn/9vb2//Pz8//w8PD/" +
                    "7e3t/+rq6v/n5+f/GgYDhxoGA4c{A50}aBgO66Obl{/c}GgYD{/d}v7+//z8/P/6+vr/+P" +
                    "j4//X19f/y8vL/7+/v/+zs7P+9ubj/GgYD1Q{A4f}BoGA//o5uX/6Obl/xoGA7oaBgP{/1" +
                    "7}7+/v/8/Pz/+vr6//f39//19fX/8vLy/+/v7/8aBgP/{A50}GgYDuhoGA/8aBgO6GgYDN" +
                    "hoGA{/22}9/f3/+/v7//n5+f/39/f/9PT0/xoGA/8{A65}GgYD{/27}+/v7/GgYD//v7+/" +
                    "/5+fn/GgYD/w{A65}aBgP{/b}8aBgP{/b}8aBgP{/b}8aBgP//v7+/8zIx/8aBgO6{A65}" +
                    "BoGA{/c}xoGA{/c}xoGA{/c}xoGA//Pysr/GgYDuhoGAxo{A65}GgYD/8/Kyv{/6}GgYD{" +
                    "/c}GgYD{/7}Pysr/GgYD/xoGA7oaBgMa{A6b}aBgM2GgYDuhoGA/8aBgO6{/a}8aBgO6Gg" +
                    "YD/xoGA7oaBgM2{A85}BoGAzYaBgO6GgYDuhoGAzY{Aaf5}//AD///gA///wAH//4AB//+" +
                    "AAf//AAD//gAA//4AAP/+AAD//gAA///gAP//4AD//+AA///gAf//4Af///w{/57}8=");
            }
            return m_HandGrabCursor;
        }
    }
    Cursor CursorFromString(string data)
    {
        byte[] bits = Convert.FromBase64String(
                    Regex.Replace(data,
                        "\\{(.)([0-9a-f]+)\\}",
                        delegate(Match m)
                        {
                            return new string(
                                m.Groups[1].Value[0],
                                int.Parse(m.Groups[2].Value,
                                    System.Globalization.NumberStyles.HexNumber));
                        }
                    )
                );
        bits[2] = 1;
        using (MemoryStream stream = new MemoryStream(bits))
        {
            using (Icon icon = new Icon(stream))
            {
                WinAPI.ICONINFO info = new WinAPI.ICONINFO();
                WinAPI.GetIconInfo(icon.Handle, out info);
                info.fIcon = false;
                info.xHotspot = bits[10];
                info.yHotspot = bits[12];
                IntPtr hCursor = WinAPI.CreateIconIndirect(ref info);
                Cursor ret = new Cursor(hCursor);
                return ret;
            }
        }
    }
    static class WinAPI
    {
        [DllImport("user32.dll")]
        public static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO piconinfo);
        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref ICONINFO piconinfo);
        [StructLayout(LayoutKind.Sequential)]
        public struct ICONINFO
        {
            public bool fIcon;
            public Int32 xHotspot;
            public Int32 yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }
    }
