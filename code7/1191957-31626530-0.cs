    try
    {
         System.Diagnostics.Process.Start("Chrome.exe", "http://www.stackoverflow.com");//or firefox.exe
    }
    catch(System.ComponentModel.Win32Exception noBrowser)
    {
        if (noBrowser.ErrorCode == -2147467259)
           MessageBox.Show(noBrowser.Message);
    }
    catch (System.Exception other)
    {
          MessageBox.Show(other.Message);
    }
