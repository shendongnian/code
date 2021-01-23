        TPhone tphone;
        TTapi tobj;
        TTerminal recordTerminal;
        TCall CurrCall;
       
        void InitializeTapi()
        {
            tobj = new TTapi();
            tobj.Initialize();
            tobj.TE_CALLNOTIFICATION += new System.EventHandler<JulMar.Tapi3.TapiCallNotificationEventArgs>(this.OnNewCall);
            tobj.TE_CALLSTATE += new System.EventHandler<JulMar.Tapi3.TapiCallStateEventArgs>(this.OnCallState);       
            tobj.TE_CALLINFOCHANGE += tobj_TE_CALLINFOCHANGE;
            foreach (TPhone tp in tobj.Phones)
            {
                tphone = tp;
                tphone.Open(PHONE_PRIVILEGE.PP_OWNER);
            }
            foreach (TAddress addr in tobj.Addresses)
            {
                if (addr.QueryMediaType(TAPIMEDIATYPES.AUDIO))
                {
                    try
                    {
                        addr.Open(TAPIMEDIATYPES.AUDIO);
                    }
                    catch (TapiException ex)
                    {
                        if (ex.ErrorCode == unchecked((int)0x80040004))
                        {
                            try
                            {
                                addr.Open(TAPIMEDIATYPES.DATAMODEM);
                            }
                            catch (Exception ex2)
                            {
                            }
                        }
                    }
                }
            }
        }
       
        void tobj_TE_CALLINFOCHANGE(object sender, TapiCallInfoChangeEventArgs e)
        {
            try
            {
                CurrCall = e.Call;
                txtCallerId.Text = e.Call.get_CallInfo(CALLINFO_STRING.CIS_CALLERIDNUMBER).ToString();
                objCallLog.CallerID = txtCallerId.Text;
                Task.Factory.StartNew(() => AnswerCall());               
            }
            catch (Exception ex)
            {
            }
        }
        void OnNewCall(object sender, TapiCallNotificationEventArgs e)
        {
            CurrCall = e.Call;
        }
        void OnCallState(object sender, EventArgs E)
        {
            try
            {
                TapiCallStateEventArgs e = E as TapiCallStateEventArgs;
                CurrCall = e.Call;
                TapiPhoneEventArgs ev = E as TapiPhoneEventArgs;
                switch (e.State)
                {
                    case CALL_STATE.CS_OFFERING:
                      
                        break;
                    case CALL_STATE.CS_CONNECTED:
                       
                        break;
                    case CALL_STATE.CS_DISCONNECTED:
                        try
                        {
                            if (recordTerminal != null)
                                recordTerminal.Stop();
                            recordTerminal = null;
                            CurrCall.Dispose();
                        }
                        catch (Exception ex)
                        {
                        }
                        finally
                        {
                            CurrCall = null;
                        }
                       
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }
        void OnCallChangeEvent(object sender, TapiCallInfoChangeEventArgs e)
        {
            CurrCall = e.Call;
        }
       
       
    private void AnswerCall()
        {
            try
            {
                lock (lockAnswer)
                {
                    if (CallStat == CallState.Offering)
                    {
                        CurrCall.Answer();
                        RecordConversation();
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
		
		 void RecordConversation()
        {
            
           
            if (CurrCall != null)
            {
                try
                {
                    recordTerminal = CurrCall.RequestTerminal(
                    TTerminal.FileRecordingTerminal,
                    TAPIMEDIATYPES.MULTITRACK, TERMINAL_DIRECTION.TD_RENDER);
                    if (recordTerminal != null)
                    {
                        recordTerminal.RecordFileName = "FileName.wav";
                        CurrCall.SelectTerminalOnCall(recordTerminal);
                        recordTerminal.Start();
                    }
                    else
                    {
                        MessageBox.Show("Error in recording file.");
                    }
                }
                catch (TapiException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
