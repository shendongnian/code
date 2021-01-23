    if (m_pWndFramework == NULL)//  CWnd* m_pWndFramework;
	
    {
		m_pWndFramework = new CWnd;
		CRect rcRange;    //set the display area
		rcRange.left = 0;
		rcRange.top = 0;
		rcRange.right = 500;
		rcRange.bottom = 500;
        //get the ID of the user control
		m_pWndFramework = GetDlgItem(IDC_TESTT1);
		//if(bCreate)
		{
			IUnknown * pUn = m_pWndFramework->GetControlUnknown(); 
			if(pUn)
			{ 
				pUn->QueryInterface(IID_IDispatch,(void **)&m_pFramework);     //m_pFramework
				bResult = TRUE;
			}
		}
	}
	m_pFramework->messageShowClose();
