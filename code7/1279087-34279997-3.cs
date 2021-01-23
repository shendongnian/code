    if (conta.Administrador)
    {
    	if (tabControl1.TabPages[0].Text != "Administrador")
    		tabControl1.TabPages.Insert(0, tbpAdministrador);
    }
    else
    	tabControl1.TabPages.RemoveAt(0);
