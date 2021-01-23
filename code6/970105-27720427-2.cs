    Private void initializetapi()
    {
        try
        {
            tobj = new TAPIClass();
            tobj.Initialize();
            IEnumAddress ea=tobj.EnumerateAddresses();
            ITAddress ln;
            uint arg3=0;
            lines=0;
            cn=new callnotification();
            cn.addtolist=new callnotification.listshow(this.status);
            tobj.ITTAPIEventNotification_Event_Event+= new TAPI3Lib.ITTAPIEventNotification_EventEventHandler(cn.Event);
            tobj.EventFilter=(int)(TAPI_EVENT.TE_CALLNOTIFICATION|
                TAPI_EVENT.TE_DIGITEVENT|
                TAPI_EVENT.TE_PHONEEVENT|
                TAPI_EVENT.TE_CALLSTATE|
                TAPI_EVENT.TE_GENERATEEVENT|
                TAPI_EVENT.TE_GATHERDIGITS|
                TAPI_EVENT.TE_REQUEST|TAPI_EVENT.TE_CALLINFOCHANGE);
    
    
            for(int i=0;i<10;i++)
            {
                ea.Next(1,out ln,ref arg3);
                ia[i]=ln;
                if(ln!=null)
                {
                    comboBox1.Items.Add(ia[i].AddressName);
                    lines++;
                }
                else
                    break;
            }
    
    
        }
        catch(Exception e)
        {
            MessageBox.Show(e.ToString());
        }
    }
    
    delegate void valueDelegate(string value);
    
    public void status(string str)
    {
        if (textBox1.InvokeRequired)
        {
            textBox1.Invoke(new valueDelegate(status), str);
        }
        else
        {
            textBox1.Text = str;
        } 
    }
    
    public void Event(TAPI3Lib.TAPI_EVENT te, object eobj)
    {
        switch (te)
        {
            case TAPI3Lib.TAPI_EVENT.TE_CALLNOTIFICATION:
            var cn = te as TAPI3Lib.ITCallNotificationEvent;
            int counter = 0;
            while (cn.Call.CallState == TAPI3Lib.CALL_STATE.CS_IDLE && counter++ < 2)
            {
                System.Threading.Thread.Sleep(1000);
            }
                status("call notification event has occured");
                break;
            case TAPI3Lib.TAPI_EVENT.TE_PHONEEVENT:
                status("A phone event!");
                break;
            case TAPI3Lib.TAPI_EVENT.TE_CALLSTATE:
                TAPI3Lib.ITCallStateEvent a = (TAPI3Lib.ITCallStateEvent)eobj;
                TAPI3Lib.ITCallInfo b = a.Call;
                switch (b.CallState)
                {
                    case TAPI3Lib.CALL_STATE.CS_INPROGRESS:
    
                       status("dialing");
                        break;
                    case TAPI3Lib.CALL_STATE.CS_CONNECTED:
                         status("Connected");
                        break;
                    case TAPI3Lib.CALL_STATE.CS_DISCONNECTED:
                        status("Disconnected");
                        break;
                    case TAPI3Lib.CALL_STATE.CS_OFFERING:
                        status("A party wants to communicate with you!");
                        break;
                    case TAPI3Lib.CALL_STATE.CS_IDLE:
                        status("Call is created!");
                        break;
                }
                break;
        }
    }
