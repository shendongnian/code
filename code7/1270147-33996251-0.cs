    public void Foo()
    {
        DoWork(chbx_Ext_tit1, txt_ext_tit_nom1, txt_ext_tit_num1);
        DoWork(chbx_Ext_tit2, txt_ext_tit_nom2, txt_ext_tit_num2);
    }
    public void DoWork(CheckBox checkbox, TextBox textbox1, TextBox textbox2)
    {
        if (checkbox.Checked == true)
        {
            FileStream fs1 = new FileStream(@"c:\LigueStats\data\TXT\Nom_joueur.txt", FileMode.Create);
            StreamWriter fichier1 = new StreamWriter(fs1);
            fichier1.Write(textbox1.Text);
            fichier1.Close();
            //Numéro
            FileStream fs2 = new FileStream(@"c:\LigueStats\data\TXT\Num_joueur.txt", FileMode.Create);
            StreamWriter fichier2 = new StreamWriter(fs2);
            fichier2.Write(textbox2.Text);
            fichier2.Close();
        }
    }
