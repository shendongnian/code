    if (size > 0)
     {
        textbox1.Text=ZKFinger10.EncodeTemplate1(g_RegTmp);  ///this code will genarate system64 string and store database field
      ZKFinger10.BIOKEY_DB_ADD(g_biokeyHandle, ++g_RegisterCount, size, g_RegTmp);
    txtPrompt.Text = string.Format("Register succeeded, fid={0}, totalCount={1}", g_RegisterCount, ZKFinger10.BIOKEY_DB_COUNT(g_biokeyHandle));
        
                                            g_IsRegister = false;
    }
