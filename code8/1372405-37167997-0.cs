        int cont = Login.accountType; //the variable from the first tab, that decides whether the account is admin type or client type
        //the variable is public static int in the first form
        if (cont == 1)
        {
            tabControl1.TabPages[0].Enabled = true;
            tabControl1.TabPages[1].Enabled = true;
            tabControl1.TabPages[2].Enabled = true;
            tabControl1.TabPages[3].Enabled = true;
        }
        else if(cont == 0)
        {
            tabControl1.TabPages[1].Enabled = false;
        }
