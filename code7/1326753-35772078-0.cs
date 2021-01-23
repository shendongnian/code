    private void sendbtn_Click(object sender, EventArgs e)
    {
        byte temp;
        temp = (byte)0x01;
        //Wyslij(sndbox.Text);
        Wyslij(new[] { temp }, 0, 1);
    }
    private void Wyslij(byte[] buffer, int offset, int count)
    {
        try { Port.Write(buffer, offset, count); }
    #if DEBUG
        catch { return; }
    #else
        catch { MessageBox.Show( "Nie można zapisać do portu\nPrawdopodobnie port jest zamknięty."); }
    #endif
    }
