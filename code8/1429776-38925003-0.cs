    HRESULT GetString(BSTR* p_bstrResult, unsigned long* ulErrCode)
	{
		HRESULT hr = S_OK;
			
		try
		{
			System::String ^systemstring = gcnew System::String("");
                        DotNetObject::o = gcnew  DotNetObject:: DotNetObjectComponent();
			*ulErrCode = (unsigned long)o->GetString(systemstring);	
			pin_ptr<const wchar_t> wch = PtrToStringChars(systemstring);
			_bstr_t bstrt(wch);
			*p_bstrResult = bstrt.GetBSTR(); // native client babysits
			delete systemstring;		
		}
		catch(Exception ^ ex)
		{
		}	
		return hr;
	}
