    public override void ProcessWindowMessage(ref System.Windows.Forms.Message m)
            {
                if (m.Msg == WM_COPYDATA)
                {
                    COPYDATASTRUCT cds;
                    cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
                    if (cds.cbData > 0)
                    {
                        byte[] data = new byte[cds.cbData];
                        Marshal.Copy(cds.lpData, data, 0, cds.cbData);
                        System.Text.Encoding unicodeStr = System.Text.Encoding.ASCII;
                        char[] myString = unicodeStr.GetChars(data);
                        string returnText = new string(myString);   // Here is the info
                    }
                    ...
