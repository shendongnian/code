    catch (Exception ex)
    {
        if (ex is xNet.ProxyException)
        {
            throw new xNet.ProxyException();
        }
        if(ex is xNet.NetException)
        {
            //MessageBox.Show(ex.Message);
            throw new xNet.NetException();
            //return false;
        }
    }
