    byte[] text = System.Text.Encoding.UTF8.GetBytes(share);
    byte[] language = System.Text.Encoding.ASCII.GetBytes("en");
    byte[] payload = new byte[1 + language.Count + text.Count];
    payload[0] = (byte)language.Count;
    System.Array.Copy(language, 0, payload, 1, language.Count);
    System.Array.Copy(text, 0, payload, 1 + language.Count, text.Count);
    NdefRecord record = new NdefRecord(NdefRecord.TnfWellKnown, NdefRecord.RtdText, new byte[0], payload);
    manager.DefaultAdapter.EnableForegroundNdefPush(this, new NdefMessage(record));
