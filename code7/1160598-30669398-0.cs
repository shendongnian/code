    public object DecryptText(string strText, string strPwd)
    {
	int i = 0;
	int c = 0;
	string strBuff = null;
	#if Not CASE_SENSITIVE_PASSWORD
	//Convert password to upper case
	//if not case-sensitive
	strPwd = Strings.UCase(strPwd);
	#endif
	//Decrypt string
	if (Strings.Len(strPwd)) {
		for (i = 1; i <= Strings.Len(strText); i++) {
			c = Strings.Asc(Strings.Mid(strText, i, 1));
			c = c - Strings.Asc(Strings.Mid(strPwd, (i % Strings.Len(strPwd)) + 1, 1));
			strBuff = strBuff + Strings.Chr(c + 0xff);
		}
	} else {
		strBuff = strText;
	}
	return strBuff;
    }
